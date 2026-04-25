using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.Components;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public class DamageFirstEnemiesAbility : AbilityPermanent
    {
        private DamageFirstEnemiesConfig _config;

        private EntitiesLifeContext _entitiesLifeContext;

        private StageProviderService _stageProviderService;

        private int _entityCount = 0;

        public DamageFirstEnemiesAbility(
            DamageFirstEnemiesConfig config,
            EntitiesLifeContext entitiesLifeContext,
            StageProviderService stageProviderService) : base(config.ID)
        {
            _config = config;
            _entitiesLifeContext = entitiesLifeContext;
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
            foreach (Entity entity in _entitiesLifeContext.Entities)
            {
                if (entity.HasComponent<Team>()
                   && entity.HasComponent<TakeDamageRequest>())
                {
                    if (entity.Team.Value == Teams.Enemies)
                    {
                        entity.TakeDamageRequest?.Invoke(_config.Damage);
                        _entityCount++;
                    }
                }

                if (_entityCount >= _config.CountEnemies)
                    return;
            }
        }
    }
}
