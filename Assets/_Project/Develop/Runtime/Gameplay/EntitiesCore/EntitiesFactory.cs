using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackAOETeleport;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.lifecycle;
using Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.Sensors;
using Assets._Project.Develop.Runtime.Gameplay.Features.Teleport;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        private readonly ConfigsProviderService _configsProviderService;

        private readonly CollidersRegistryService _collidersRegistryService;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _configsProviderService = _container.Resolve<ConfigsProviderService>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateRigidbodyEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/TestEntity");

            RigidbodyMovementConfig config = _configsProviderService.GetConfig<RigidbodyMovementConfig>();

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(config.MoveSpeed))
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new ReactiveVariable<float>(100))
                .AddMaxEnergy(new ReactiveVariable<float>(100))
                .AddCurrentEnergy(new ReactiveVariable<float>(100))
                .AddIsDead()
                .AddEnergyRecoveryInitialTime(new ReactiveVariable<float>(5))
                .AddEnergyRecoveryCurrentTime()
                .AddEnergyRecoveryValue(new ReactiveVariable<float>(10))
                .AddEnergyTeleportValue(new ReactiveVariable<float>(30))
                .AddStartTeleportEvent()
                .AddStartTeleportRequest()
                .AddEndTeleportEvent()
                .AddRadiusTeleport(new ReactiveVariable<float>(5))
                .AddRadiusAttack(new ReactiveVariable<float>(15))
                .AddDamageAttack(new ReactiveVariable<float>(60))
                .AddinAttackProcess()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddTakeDamageRequest();

            ICompositCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositCondition mustSelfReleased = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositCondition canTeleport = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentEnergy.Value >= entity.EnergyTeleportValue.Value));

            entity
                .AddMustDie(mustDie)
                .AddCanTeleport(canTeleport)
                .AddMustSelfReleased(mustSelfReleased);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new EnergyRecoveryTimerSystem())
                .AddSystem(new StartTeleportSystem())
                .AddSystem(new TeleportManaConsumptionSystem())
                .AddSystem(new TeleportProcessSystem())
                .AddSystem(new StartAttackAOETeleportSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnAOETeleportSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new EndAttackAOETeleportSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfRealeseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateCharacterControllerEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/CharacterControllerEntity");

            CharacterControllerMovementConfig config = _configsProviderService.GetConfig<CharacterControllerMovementConfig>();

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(config.MoveSpeed))
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new ReactiveVariable<float>(100))
                .AddTakeDamageRequest()
                .AddIsDead();

            entity
                .AddSystem(new CharacterControllerMovementSystem())
                .AddSystem(new CharacterControllerRotationSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public void Release(Entity entity) => _entitiesLifeContext.Release(entity);

        private Entity CreateEmpty() => new Entity();
    }
}
