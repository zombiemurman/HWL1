using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.inputfeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;

        private readonly TimerServiceFactory _timerServiceFactory;

        private readonly AIBrainsContext _brainContext;

        private readonly InputFactory _inputFactory;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;

            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();

            _brainContext = _container.Resolve<AIBrainsContext>();

            _inputFactory = _container.Resolve<InputFactory>();

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public StateMachineBrain CreateBehaviourEntity_TeleportRandom(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomTeleportStateMachine(entity);
            StateMachineBrain machineBrain = new StateMachineBrain(stateMachine);

            _brainContext.SetFor(entity, machineBrain);

            return machineBrain;
        }

        public StateMachineBrain CreateBehaviourEntity_CurrentTargetTeleport(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine TeleportCurrentTargetState = CreateTeleportCurrentTargetStateMachine(entity);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);

            AIParallelState parallelState = new AIParallelState(findTargetState, TeleportCurrentTargetState);

            AIStateMachine rootSateMachine = new AIStateMachine();
            rootSateMachine.AddState(parallelState);

            StateMachineBrain stateMachineBrain = new StateMachineBrain(rootSateMachine);

            _brainContext.SetFor(entity, stateMachineBrain);

            return stateMachineBrain;
        }

        private AIStateMachine CreateRandomTeleportStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            TeleportRandomRadiusState teleportRandomRadiusState = new TeleportRandomRadiusState(entity);

            EmptyState emptyState = new EmptyState();

            bool teleportationEnded = false;

            TimerService idleTimer = _timerServiceFactory.Create(1f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));
            disposables.Add(emptyState.Entered.Subscribe(() => teleportationEnded = false));
            disposables.Add(entity.EndTeleportEvent.Subscribe(() => teleportationEnded = true));

            ICompositCondition emptyToTeleportCondition = new CompositeCondition()
               .Add(new FuncCondition(() => idleTimer.IsOver))
               .Add(new FuncCondition(() => entity.EnergyTeleportValue.Value <= entity.CurrentEnergy.Value));

            ICondition teleportToEmptyCondition = new FuncCondition(() => teleportationEnded);

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(emptyState);
            stateMachine.AddState(teleportRandomRadiusState);
            
            stateMachine.AddTransition(teleportRandomRadiusState, emptyState, teleportToEmptyCondition);
            stateMachine.AddTransition(emptyState, teleportRandomRadiusState, emptyToTeleportCondition); 

            return stateMachine;
        }

        private AIStateMachine CreateTeleportCurrentTargetStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            TeleportCurrentTargetState TeleportCurrentTargetState = new TeleportCurrentTargetState(entity);

            EmptyState emptyState = new EmptyState();

            bool teleportationEnded = false;

            TimerService idleTimer = _timerServiceFactory.Create(2f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));
            disposables.Add(emptyState.Entered.Subscribe(() => teleportationEnded = false));
            disposables.Add(entity.EndTeleportEvent.Subscribe(() => teleportationEnded = true));

            ICompositCondition movementTimerEndedCondition = new CompositeCondition()
                .Add(new FuncCondition(() => idleTimer.IsOver))
                .Add(new FuncCondition(() => entity.EnergyTeleportValue.Value <= entity.CurrentEnergy.Value));

            ICondition idleTimerEndedCondition = new FuncCondition(() => teleportationEnded);

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(emptyState);
            stateMachine.AddState(TeleportCurrentTargetState);
            
            stateMachine.AddTransition(TeleportCurrentTargetState, emptyState, idleTimerEndedCondition);
            stateMachine.AddTransition(emptyState, TeleportCurrentTargetState, movementTimerEndedCondition); 

            return stateMachine;
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity)
        {
            AIStateMachine combatState = CreateAttackStateMachine(entity);

            IInputService desktopInput = _inputFactory.CreateDesktopInput();
            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputFactory.CreateDesktopInput());

            //ReactiveVariable<Entity> currenttarget = entity.CurrentTarget;

            ICompositCondition fromMovementToCombatStateCondition = new CompositeCondition()
                //.Add(new FuncCondition(() => currenttarget.Value != null))
                .Add(new FuncCondition(() => desktopInput.Direction == Vector3.zero));

            ICompositCondition fromCombatToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                //.Add(new FuncCondition(() => currenttarget.Value == null))
                .Add(new FuncCondition(() => desktopInput.Direction != Vector3.zero));

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState, combatState, fromMovementToCombatStateCondition);
            behaviour.AddTransition(combatState, movementState, fromCombatToMovementStateCondition);

            StateMachineBrain stateMachineBrain = new StateMachineBrain(behaviour);

            _brainContext.SetFor(entity, stateMachineBrain);

            return stateMachineBrain;
        }

        private AIStateMachine CreateAttackStateMachine(Entity entity)
        {
            RotateToMouseState rotateToMouseState = new RotateToMouseState(entity, _inputFactory.CreateMouseRotationInput());

            AttackTriggerState attackTriggerState = new AttackTriggerState(entity, _inputFactory.CreateAttackInput());

            ICondition canAttack = entity.CanStartAttack;

            //Transform transform = entity.Transform;

            //ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(canAttack);

            ReactiveVariable<bool> inAttackProcess = entity.inAttackProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(rotateToMouseState);
            stateMachine.AddState(attackTriggerState);

            stateMachine.AddTransition(rotateToMouseState, attackTriggerState, fromRotateToAttackCondition);
            stateMachine.AddTransition(attackTriggerState, rotateToMouseState, fromAttackToRotateStateCondition);

            return stateMachine;
        }

    }
}
