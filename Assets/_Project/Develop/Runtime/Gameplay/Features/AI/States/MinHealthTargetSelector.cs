using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class MinHealthTargetSelector : ITargetSelector
    {
        private Entity _source;
        private Transform _sourceTransform;

        public MinHealthTargetSelector(Entity entity)
        {
            _source = entity;
            _sourceTransform = entity.EntityTransform;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<CurrentHealth>();

                return result;

            });

            if (selectedTargets.Any() == false)
                return null;

            Entity closestTarget = selectedTargets.First();
            float minHealth = closestTarget.CurrentHealth.Value;

            foreach (Entity target in selectedTargets)
            {
                float targetHealth = target.CurrentHealth.Value;
                
                if (targetHealth < minHealth)
                {
                    minHealth = targetHealth;
                    closestTarget = target;
                }
            }

            return closestTarget;
        }
    }
}
