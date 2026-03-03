namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportEvent StartTeleportEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartTeleportEvent => StartTeleportEventC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartTeleportEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartTeleportEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportRequest StartTeleportRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartTeleportRequest => StartTeleportRequestC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartTeleportRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartTeleportRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EndTeleportEvent EndTeleportEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EndTeleportEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndTeleportEvent => EndTeleportEventC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndTeleportEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EndTeleportEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndTeleportEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EndTeleportEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport CanTeleportC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition CanTeleport => CanTeleportC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanTeleport(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EnergyTeleportValue EnergyTeleportValueC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EnergyTeleportValue>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyTeleportValue => EnergyTeleportValueC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyTeleportValue()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EnergyTeleportValue() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyTeleportValue(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EnergyTeleportValue() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EntityTransform EntityTransformC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EntityTransform>();

		public UnityEngine.Transform EntityTransform => EntityTransformC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEntityTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EntityTransform() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport RadiusTeleportC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RadiusTeleport => RadiusTeleportC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRadiusTeleport()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRadiusTeleport(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection MoveDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveSpeed MoveSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveSpeed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationSpeed RotationSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationSpeed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentEnergy CurrentEnergyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentEnergy>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentEnergy => CurrentEnergyC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentEnergy()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentEnergy() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentEnergy(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentEnergy() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxEnergy MaxEnergyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxEnergy>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxEnergy => MaxEnergyC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxEnergy()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxEnergy() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxEnergy(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxEnergy() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition MustDie => MustDieC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfReleased MustSelfReleasedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfReleased>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition MustSelfReleased => MustSelfReleasedC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfReleased(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfReleased() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryInitialTime EnergyRecoveryInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRecoveryInitialTime => EnergyRecoveryInitialTimeC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryCurrentTime EnergyRecoveryCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRecoveryCurrentTime => EnergyRecoveryCurrentTimeC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryValue EnergyRecoveryValueC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryValue>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRecoveryValue => EnergyRecoveryValueC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryValue()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryValue() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryValue(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryValue() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.RadiusAttack RadiusAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.RadiusAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RadiusAttack => RadiusAttackC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRadiusAttack()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.RadiusAttack() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRadiusAttack(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.RadiusAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.DamageAttack DamageAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.DamageAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DamageAttack => DamageAttackC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageAttack()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.DamageAttack() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageAttack(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.DamageAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.inAttackProcess inAttackProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.inAttackProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> inAttackProcess => inAttackProcessC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddinAttackProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.inAttackProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddinAttackProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.inAttackProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamageRequest TakeDamageRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamageRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamageRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamageRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value});
		}

	}
}
