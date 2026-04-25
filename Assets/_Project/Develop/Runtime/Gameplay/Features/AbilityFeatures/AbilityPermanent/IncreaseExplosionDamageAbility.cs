using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public class IncreaseExplosionDamageAbility : AbilityPermanent
    {
        private IncreaseExplosionDamageConfig _config;

        private Entity _entity;

        public IncreaseExplosionDamageAbility(
            Entity entity, 
            IncreaseExplosionDamageConfig config) : base(config.ID)
        {
            _config = config;
            _entity = entity;
        }

        public override void Activate()
        {
            if(_entity.HasComponent<AbilityStorage>())
            {
                Entity abilityEntity = _entity.AbilityStorage[AbilityTypes.Explosion];

                abilityEntity.ExplosionDamage.Value *= _config.IncreaseDamagePercent;
            }
        }
    }
}
