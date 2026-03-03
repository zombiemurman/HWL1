using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;
using static UnityEngine.GridBrushBase;


namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures
{
    public class RigidbodyRotationSystem : IUpdatableSystem, IInitializableSystem
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<float> _rotationSpeed;

        private Rigidbody _rigidbody;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _rotationSpeed = entity.RotationSpeed;
            _rigidbody = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_moveDirection.Value == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_rigidbody.velocity);
            _rigidbody.MoveRotation(Quaternion.Slerp(_rigidbody.rotation, targetRotation, _rotationSpeed.Value * deltaTime));
        }
    }
}

