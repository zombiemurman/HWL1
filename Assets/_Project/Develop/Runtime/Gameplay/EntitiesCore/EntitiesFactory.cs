using Assets._Project.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackAOETeleport;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.inputfeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.lifecycle;
using Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.Sensors;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.Teleport;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

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

        public Entity CreateBaseEntity(Vector3 position, GhostConfig ghostConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, ghostConfig.PrefabPath);

            RigidbodyMovementConfig config = _configsProviderService.GetConfig<RigidbodyMovementConfig>();

            Vector3 direction = (Vector3.zero - position).normalized;

            entity
                .AddTeam(new ReactiveVariable<Teams>(Teams.Enemies))
                .AddIsTouchAnotherTeam()
                .AddIsTouchDeatMask()
                .AddBodyContacDamage(new ReactiveVariable<float>(ghostConfig.BodyContactDamage))
                .AddinAttackProcess(new ReactiveVariable<bool>(true))
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddIsMoving()
                .AddRotationDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(ghostConfig.MoveSpeed))
                .AddRotationSpeed(new ReactiveVariable<float>(ghostConfig.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(ghostConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(ghostConfig.MaxHealth))
                .AddIsDead()
                .AddTakeDamageRequest()
                .AddDeathMask(Layers.CharactersMask)
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));

            ICompositCondition mustDie = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0))
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));

            ICompositCondition mustSelfReleased = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddMustDie(mustDie)
                .AddMustSelfReleased(mustSelfReleased);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new BodyContactsEntitiesOnlyMainHeroSystem())
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfRealeseSystem(_entitiesLifeContext));

            //_entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateCatapultEntity(Vector3 position, CatapultConfig catapultConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, catapultConfig.PrefabPath);

            Vector3 direction = (Vector3.zero - position).normalized;

            entity
                .AddIsStopMoving()
                .AddMovingToDistance(new ReactiveVariable<float>(catapultConfig.MovingToDistance))
                .AddTeam(new ReactiveVariable<Teams>(Teams.Enemies))
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddIsMoving()
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(catapultConfig.MoveSpeed))
                .AddRotationSpeed(new ReactiveVariable<float>(catapultConfig.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(catapultConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(catapultConfig.MaxHealth))
                .AddIsDead()
                .AddTakeDamageRequest();

            ICompositCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositCondition mustSelfReleased = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.IsStopMoving.Value == false));

            entity
                .AddCanMove(canMove)
                .AddMustDie(mustDie)
                .AddMustSelfReleased(mustSelfReleased);

            entity
                .AddSystem(new MovingToDistanceSystem())
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfRealeseSystem(_entitiesLifeContext));

            //_entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateCharacterControllerEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/CharacterControllerEntity");

            CharacterControllerMovementConfig config = _configsProviderService.GetConfig<CharacterControllerMovementConfig>();

            entity
                .AddMoveDirection()
                .AddRotationDirection()
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

        public Entity CreateHeroEntity2(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Hero");

            entity
                .AddMoveDirection()
                .AddIsBullet()
                .AddRotationDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddIsMoving()
                .AddRotationSpeed(new ReactiveVariable<float>(900))
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new ReactiveVariable<float>(100))
                .AddIsDead()
                .AddTakeDamageRequest()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(3))
                .AddAttackProcessCurrentTime()
                .AddinAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVariable<float>(1))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVariable<float>(50))
                .AddAttackCancelEvent()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(2))
                .AddAttackCooldownCurentTime()
                .AddInAttackCooldown();

            ICompositCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositCondition mustSelfReleased = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value));
                            //.Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false))
                .Add(new FuncCondition(() => entity.inAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.IsMoving.Value == false));

            ICompositCondition mustCancelAttack = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.IsMoving.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfReleased(mustSelfReleased)
                .AddCanStartAttack(canStartAttack)
                .AddMustCancelAttack(mustCancelAttack);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new AttackCancelSystem())
                .AddSystem(new StartAttackExplosionSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(this))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfRealeseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateProjectile(Vector3 position, Vector3 direction, float damage)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Projectile");

            entity
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddIsBullet(new ReactiveVariable<bool>(true))
                .AddIsMoving()
                .AddinAttackProcess(new ReactiveVariable<bool>(true))
                .AddRadiusAttack()
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVariable<float>(9999))
                .AddIsDead()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContacDamage(new ReactiveVariable<float>(damage))
                .AddDeathMask(1 << LayerMask.NameToLayer("Characters"))
                .AddIsTouchDeatMask();

            ICompositCondition canMove = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsTouchDeatMask.Value));

            ICompositCondition mustSelfReleased = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfReleased(mustSelfReleased);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new BodyContactsEntitiesOnlyMainHeroSystem())
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfRealeseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }


        public Entity CreateProjectileHero(Vector3 position, Vector3 direction, float damage)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Projectile");

            entity
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddIsBullet(new ReactiveVariable<bool>(true))
                .AddIsMoving()
                .AddinAttackProcess(new ReactiveVariable<bool>(true))
                .AddRadiusAttack()
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVariable<float>(9999))
                .AddIsDead()
                .AddContactsDetectingMask(Layers.EnemyMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContacDamage(new ReactiveVariable<float>(damage))
                .AddDeathMask(Layers.EnemyMask)
                .AddIsTouchDeatMask();

            ICompositCondition canMove = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsTouchDeatMask.Value));

            ICompositCondition mustSelfReleased = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfReleased(mustSelfReleased);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                //.AddSystem(new BodyContactsEntitiesOnlyMainHeroSystem())
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfRealeseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }


        public Entity CreateHeroEntity(Vector3 position, HeroConfig heroConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, Vector3.zero, heroConfig.PrefabPath);

            entity
                .AddIsMainHero()
                .AddTeam(new ReactiveVariable<Teams>(Teams.MainHero))
                .AddMaxHealth(new ReactiveVariable<float>(heroConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(heroConfig.MaxHealth))
                .AddIsDead()
                .AddTakeDamageRequest()
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                
                .AddAbilityStorage();

            ICompositCondition mustSelfReleased = new CompositeCondition()
                            .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfReleased(mustSelfReleased);

            entity
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfRealeseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateTurel(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/TurelEntity");

            entity
                .AddStartAttackEvent()
                .AddinAttackProcess()
                .AddEndAttackEvent()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(1))
                .AddAttackProcessCurrentTime()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(1))
                .AddAttackCooldownCurentTime()
                .AddAttackDelayTime(new ReactiveVariable<float>(1))
                .AddInstantAttackDamage(new ReactiveVariable<float>(150))
                .AddAttackDelayEndEvent()
                .AddAttackCancelEvent()
                .AddInAttackCooldown()
                .AddTeam(new ReactiveVariable<Teams>(Teams.MainHero))
                .AddRotationDirection()
                .AddCurrentTarget()
                .AddStartAttackRequest()
                .AddRotationSpeed(new ReactiveVariable<float>(600))
                .AddRadiusAttack(new ReactiveVariable<float>(5))
                .AddContactsDetectingMask(Layers.EnemyMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));

            ICompositCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.inAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));

            entity
                .AddCanStartAttack(canStartAttack);

            entity
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new StartAttackRequestSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootForwardSystem(this))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem()); ;

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateMine(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Bomb");

            entity
                .AddTeam(new ReactiveVariable<Teams>(Teams.MainHero))
                .AddStartTimeBombEvent()
                .AddEndAttackBombEvent()
                .AddInBombTimeProcess()
                .AddExplosionPoint()
                .AddInitialTimeBomb(new ReactiveVariable<float>(1))
                .AddCurrentTimeBomb()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddinAttackProcess()
                .AddDamageAttack(new ReactiveVariable<float>(120))
                .AddRadiusAttack(new ReactiveVariable<float>(2))
                .AddContactsDetectingMask(Layers.EnemyMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));

            ICompositCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.inAttackProcess.Value == false));

            entity
                 .AddCanStartAttack(canStartAttack);

            entity
                .AddSystem(new DetectedBombSystem())
                .AddSystem(new ProcessTimerBombSystem())
                .AddSystem(new BombStartAttackSystem())
                .AddSystem(new StartAttackExplosionSystem())
                .AddSystem(new BombContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new BodyContactsEntitiesExceptedMainHeroSystem())
                .AddSystem(new BombDamageSystem())
                .AddSystem(new EndAttackBombSystem(this));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateExplosionAbility()
        {
            Entity entity = CreateEmpty();

            entity
                .AddAbilityActive()
                .AddExplosionCamera(Camera.main)
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddinAttackProcess()
                .AddExplosionRadius(new ReactiveVariable<float>(5))
                .AddExplosionDamage(new ReactiveVariable<float>(50))
                .AddExplosionPoint()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(0.5f))
                .AddAttackCooldownCurentTime()
                .AddInAttackCooldown()
                .AddContactsDetectingMask(Layers.EnemyMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));

            ICompositCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false))
                .Add(new FuncCondition(() => entity.inAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.AbilityActive.Value));

            entity
                .AddCanStartAttack(canStartAttack);

            entity
                .AddSystem(new StartAttackExplosionSystem())
                .AddSystem(new ExplosionContactSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new BodyContactsEntitiesExceptedMainHeroSystem())
                .AddSystem(new ExplosionDamageSystem())
                .AddSystem(new ExplosionEndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateInstallMineAbility()
        {
            Entity entity = CreateEmpty();

            entity
                .AddAbilityActive()
                .AddSetMineRequest();

            ICompositCondition canSetMine = new CompositeCondition()
                .Add(new FuncCondition(() => entity.AbilityActive.Value));

            entity
                .AddCanSetMine(canSetMine);

            entity
                .AddSystem(new SetMineSystem(this));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateInstallTurelAbility()
        {
            Entity entity = CreateEmpty();

            entity
                .AddAbilityActive()
                .AddSetMineRequest();

            ICompositCondition canSetMine = new CompositeCondition()
                .Add(new FuncCondition(() => entity.AbilityActive.Value));

            entity
                .AddCanSetMine(canSetMine);

            entity
                .AddSystem(new SetTurelSystem(this, _container.Resolve<BrainsFactory>()));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateShootAbility(Entity entityParent, ShootAbilityConfig config)
        {
            Entity entity = CreateEmpty();

            entity
                .AddShootPoint(entityParent.ShootPoint)
                .AddAbilityActive(new ReactiveVariable<bool>(true))
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddinAttackProcess()
                .AddEndAttackEvent()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(config.AttackProcessTime))
                .AddAttackProcessCurrentTime()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(config.Cooldown))
                .AddAttackCooldownCurentTime()
                .AddAttackDelayTime(new ReactiveVariable<float>(config.Delay))
                .AddInstantAttackDamage(new ReactiveVariable<float>(config.Damage))
                .AddAttackDelayEndEvent()
                .AddAttackCancelEvent()
                .AddInAttackCooldown();

            ICompositCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entityParent.IsStopMoving.Value))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false))
                .Add(new FuncCondition(() => entity.inAttackProcess.Value == false));

            entity
                .AddCanStartAttack(canStartAttack);

            entity
                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(this))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public void AddAbility(Entity entity, AbilityTipes abilityTipes, Entity entityAbility)
        {
            if (entity.TryGetAbilityStorage(out Dictionary<AbilityTipes, Entity> abilityStorage))
            {
                abilityStorage.Add(abilityTipes, entityAbility);
                entity.AddChildEntity(entityAbility);
            }
        }

        public void Release(Entity entity) => _entitiesLifeContext.Release(entity);

        private Entity CreateEmpty() => new Entity();
    }
}
