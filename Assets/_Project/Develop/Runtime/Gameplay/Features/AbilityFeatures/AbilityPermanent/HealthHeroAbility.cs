using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public class HealthHeroAbility : AbilityPermanent
    {
        private HealthAbilityConfig _config;

        private StageProviderService _stageProviderService;

        private Entity _entity;

        public HealthHeroAbility(
            Entity entity,
            HealthAbilityConfig config,
            StageProviderService stageProviderService) : base(config.ID)
        {
            _entity = entity;
            _config = config;
            _stageProviderService = stageProviderService;
        }

        public override void Activate()
        {
            _stageProviderService.NextStage += OnNextStage;
        }

        public void Dispose()
        {
            _stageProviderService.NextStage -= OnNextStage;
        }

        private void OnNextStage()
        {
            _entity.CurrentHealth.Value *= _config.HealthPercent;

            if (_entity.CurrentHealth.Value > _entity.MaxHealth.Value)
                _entity.CurrentHealth.Value = _entity.MaxHealth.Value;
        }
    }
}
