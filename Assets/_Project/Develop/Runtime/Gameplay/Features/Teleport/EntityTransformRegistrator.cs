using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class EntityTransformRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _entityTransform;

        public override void Register(Entity entity)
        {
            entity.AddEntityTransform(_entityTransform);
        }
    }
}
