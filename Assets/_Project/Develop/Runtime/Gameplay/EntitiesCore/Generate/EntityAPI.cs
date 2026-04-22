namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportEvent StartTeleportEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartTeleportEvent => StartTeleportEventC.Value;

		public bool TryGetStartTeleportEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetStartTeleportRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.StartTeleportRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetEndTeleportEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EndTeleportEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetCanTeleport(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanTeleport(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EnergyTeleportValue EnergyTeleportValueC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EnergyTeleportValue>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyTeleportValue => EnergyTeleportValueC.Value;

		public bool TryGetEnergyTeleportValue(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EnergyTeleportValue component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetEntityTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EntityTransform component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEntityTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.EntityTransform() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport RadiusTeleportC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RadiusTeleport => RadiusTeleportC.Value;

		public bool TryGetRadiusTeleport(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRadiusTeleport()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRadiusTeleport(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.RadiusTeleport() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportManaConsumptionEvent TeleportManaConsumptionEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportManaConsumptionEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportManaConsumptionEvent => TeleportManaConsumptionEventC.Value;

		public bool TryGetTeleportManaConsumptionEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportManaConsumptionEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportManaConsumptionEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportManaConsumptionEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportManaConsumptionEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportManaConsumptionEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Components.Team TeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Components.Team>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> Team => TeamC.Value;

		public bool TryGetTeam(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Components.Team component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Components.Team() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Components.Team() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Components.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Components.IsTouchAnotherTeam>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Components.IsTouchAnotherTeam component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Components.IsTouchAnotherTeam() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Components.IsTouchAnotherTeam() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public bool TryGetContactCollidersBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeatMask IsTouchDeatMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeatMask>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchDeatMask => IsTouchDeatMaskC.Value;

		public bool TryGetIsTouchDeatMask(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeatMask component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeatMask()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeatMask() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeatMask(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeatMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection MoveDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveDirection() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationDirection RotationDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationDirection() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationDirection() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveSpeed MoveSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MoveSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetRotationSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.RotationSpeed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsMoving IsMovingC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsMoving>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsMoving component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsMoving() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsMoving() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanMove CanMoveC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanMove>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanMove() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanRotate CanRotateC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanRotate>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CanRotate() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MovingToDistance MovingToDistanceC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MovingToDistance>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MovingToDistance => MovingToDistanceC.Value;

		public bool TryGetMovingToDistance(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MovingToDistance component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMovingToDistance()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MovingToDistance() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMovingToDistance(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.MovingToDistance() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsStopMoving IsStopMovingC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsStopMoving>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsStopMoving => IsStopMovingC.Value;

		public bool TryGetIsStopMoving(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsStopMoving component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsStopMoving()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsStopMoving() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsStopMoving(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures.IsStopMoving() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures.IsMainHero IsMainHeroC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures.IsMainHero>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMainHero => IsMainHeroC.Value;

		public bool TryGetIsMainHero(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures.IsMainHero component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMainHero()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures.IsMainHero() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMainHero(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures.IsMainHero() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetMaxHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetCurrentEnergy(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentEnergy component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetMaxEnergy(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxEnergy component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetIsDead(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetMustDie(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfReleased MustSelfReleasedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfReleased>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition MustSelfReleased => MustSelfReleasedC.Value;

		public bool TryGetMustSelfReleased(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfReleased component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfReleased(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfReleased() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryInitialTime EnergyRecoveryInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRecoveryInitialTime => EnergyRecoveryInitialTimeC.Value;

		public bool TryGetEnergyRecoveryInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetEnergyRecoveryCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetEnergyRecoveryValue(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryValue component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryValue()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryValue() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRecoveryValue(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.EnergyRecoveryValue() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = new System.Collections.Generic.List<UnityEngine.Collider>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionPoint ExplosionPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionPoint>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> ExplosionPoint => ExplosionPointC.Value;

		public bool TryGetExplosionPoint(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionPoint component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionPoint()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionPoint() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionPoint(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionPoint() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionRadius ExplosionRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ExplosionRadius => ExplosionRadiusC.Value;

		public bool TryGetExplosionRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionRadius() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionRadius() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionDamage ExplosionDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ExplosionDamage => ExplosionDamageC.Value;

		public bool TryGetExplosionDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionCamera ExplosionCameraC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionCamera>();

		public UnityEngine.Camera ExplosionCamera => ExplosionCameraC.Value;

		public bool TryGetExplosionCamera(out UnityEngine.Camera value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionCamera component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Camera);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionCamera(UnityEngine.Camera value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures.ExplosionCamera() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InitialTimeBomb InitialTimeBombC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InitialTimeBomb>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> InitialTimeBomb => InitialTimeBombC.Value;

		public bool TryGetInitialTimeBomb(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InitialTimeBomb component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInitialTimeBomb()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InitialTimeBomb() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInitialTimeBomb(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InitialTimeBomb() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.CurrentTimeBomb CurrentTimeBombC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.CurrentTimeBomb>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentTimeBomb => CurrentTimeBombC.Value;

		public bool TryGetCurrentTimeBomb(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.CurrentTimeBomb component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTimeBomb()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.CurrentTimeBomb() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTimeBomb(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.CurrentTimeBomb() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.StartTimeBombEvent StartTimeBombEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.StartTimeBombEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartTimeBombEvent => StartTimeBombEventC.Value;

		public bool TryGetStartTimeBombEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.StartTimeBombEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartTimeBombEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.StartTimeBombEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartTimeBombEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.StartTimeBombEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InBombTimeProcess InBombTimeProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InBombTimeProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InBombTimeProcess => InBombTimeProcessC.Value;

		public bool TryGetInBombTimeProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InBombTimeProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInBombTimeProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InBombTimeProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInBombTimeProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.InBombTimeProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.EndAttackBombEvent EndAttackBombEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.EndAttackBombEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndAttackBombEvent => EndAttackBombEventC.Value;

		public bool TryGetEndAttackBombEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.EndAttackBombEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackBombEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.EndAttackBombEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackBombEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures.EndAttackBombEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.RadiusAttack RadiusAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.RadiusAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RadiusAttack => RadiusAttackC.Value;

		public bool TryGetRadiusAttack(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.RadiusAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetDamageAttack(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.DamageAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetinAttackProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.inAttackProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetTakeDamageRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamageRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamageRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition MustCancelAttack => MustCancelAttackC.Value;

		public bool TryGetMustCancelAttack(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCancelAttack(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent AttackCancelEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackCancelEvent => AttackCancelEventC.Value;

		public bool TryGetAttackCancelEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCancelEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCancelEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurentTime AttackCooldownCurentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownCurentTime => AttackCooldownCurentTimeC.Value;

		public bool TryGetAttackCooldownCurentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.BodyContacDamage BodyContacDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.BodyContacDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> BodyContacDamage => BodyContacDamageC.Value;

		public bool TryGetBodyContacDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.BodyContacDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContacDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.BodyContacDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContacDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.BodyContacDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsBullet IsBulletC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsBullet>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsBullet => IsBulletC.Value;

		public bool TryGetIsBullet(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsBullet component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsBullet()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsBullet() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsBullet(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsBullet() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetMine ItSetMineC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetMine>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ItSetMine => ItSetMineC.Value;

		public bool TryGetItSetMine(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetMine component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddItSetMine()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetMine() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddItSetMine(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetMine() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetExplosion ItSetExplosionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetExplosion>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ItSetExplosion => ItSetExplosionC.Value;

		public bool TryGetItSetExplosion(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetExplosion component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddItSetExplosion()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetExplosion() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddItSetExplosion(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ItSetExplosion() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanSetMine CanSetMineC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanSetMine>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition CanSetMine => CanSetMineC.Value;

		public bool TryGetCanSetMine(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanSetMine component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanSetMine(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanSetMine() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.SetMineRequest SetMineRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.SetMineRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> SetMineRequest => SetMineRequestC.Value;

		public bool TryGetSetMineRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.SetMineRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSetMineRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.SetMineRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSetMineRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.SetMineRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget CurrentTargetC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityStorage AbilityStorageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityStorage>();

		public System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityTypes, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> AbilityStorage => AbilityStorageC.Value;

		public bool TryGetAbilityStorage(out System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityTypes, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityStorage component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityTypes, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityStorage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityStorage() {Value = new System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityTypes, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityStorage(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityTypes, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityStorage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityActive AbilityActiveC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityActive>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> AbilityActive => AbilityActiveC.Value;

		public bool TryGetAbilityActive(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityActive component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityActive()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityActive() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityActive(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.AbilityActive() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.DebugText DebugTextC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.DebugText>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> DebugText => DebugTextC.Value;

		public bool TryGetDebugText(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.DebugText component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDebugText()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.DebugText() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDebugText(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility.DebugText() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public bool TryGetCharacterController(out UnityEngine.CharacterController value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CharacterController);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value});
		}

	}
}
