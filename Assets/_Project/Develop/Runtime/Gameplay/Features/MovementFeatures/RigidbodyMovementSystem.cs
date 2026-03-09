using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures
{
    public class RigidbodyMovementSystem : IUpdatableSystem, IInitializableSystem
    {
        private ReactiveVariable<Vector3> _moveDirection;

        private ReactiveVariable<float> _moveSpeed;

        private ReactiveVariable<bool> _isMoving;

        private ReactiveVariable<bool> _isBullet;

        private ICompositCondition _canMove;

        private Rigidbody _rigidbody;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _rigidbody = entity.Rigidbody;
            _canMove = entity.CanMove;
            _isBullet = entity.IsBullet;

            _isMoving = entity.IsMoving;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canMove.Evaluate() == false)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _isMoving.Value = velocity.magnitude > 0;

            _rigidbody.velocity = velocity;

            if (_isBullet.Value)
                Debug.Log("Bullet velosity - " + velocity);
        }
    }
}

