using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures
{
    public class CharacterControllerRotationSystem : IUpdatableSystem, IInitializableSystem
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<float> _rotationSpeed;

        private CharacterController _characterController;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _rotationSpeed = entity.RotationSpeed;
            _characterController = entity.CharacterController;
        }

        public void OnUpdate(float deltaTime)
        {
            Quaternion lookRotation = Quaternion.LookRotation(_moveDirection.Value);

            float step = _rotationSpeed.Value * deltaTime;

            _characterController.transform.rotation = Quaternion.RotateTowards(_characterController.transform.rotation, lookRotation, step);
        }
    }
}

