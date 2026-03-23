using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Enemies;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures
{
    public class ClearAllEnemiesStage : IStage
    {
        private ClearAllEnemiesStageConfig _config;

        private ReactiveEvent _completed = new();

        private EnemiesFactory _enemiesFactory;

        private EntitiesLifeContext _entitiesLifeContext;

        private bool _inProcess;

        private Dictionary<Entity, IDisposable> _spawnEnemiesToRemoveReason = new();

        public ClearAllEnemiesStage(
            ClearAllEnemiesStageConfig config,
            EnemiesFactory enemiesFactory,
            EntitiesLifeContext entitiesLifeContext)
        {
            _config = config;
            _enemiesFactory = enemiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyEvent Completed => _completed;

        public void Cleanup()
        {
            foreach(KeyValuePair<Entity, IDisposable> item in _spawnEnemiesToRemoveReason)
            {
                item.Value.Dispose();

                _entitiesLifeContext.Release(item.Key);
            }

            _spawnEnemiesToRemoveReason.Clear();

            _inProcess = false;
        }

        public void Dispose()
        {
            foreach (KeyValuePair<Entity, IDisposable> item in _spawnEnemiesToRemoveReason)
                item.Value.Dispose();

            _spawnEnemiesToRemoveReason.Clear();
            _inProcess = false;
        }

        public void Start()
        {
            if (_inProcess)
                throw new InvalidOperationException("Game mode already start");

            SpawnEnemies();

            _inProcess = true;
        }

        public void Update(float deltaTime)
        {
            if (_inProcess == false)
                return;

            if (_spawnEnemiesToRemoveReason.Count == 0)
                ProcessEnd();
        }

        private void ProcessEnd()
        {
            _inProcess = false;
            _completed.Invoke();
        }

        private void SpawnEnemies()
        {
            foreach (EnemyItemConfig enemyItemConfig in _config.EnemyItems)
                SpawnEnemy(enemyItemConfig);

        }

        private void SpawnEnemy(EnemyItemConfig enemyItemConfig)
        {
            Entity spawnedEnemy = _enemiesFactory.Create(enemyItemConfig.SpawnPosition, enemyItemConfig.EnemyConfig);

            IDisposable removeReason = spawnedEnemy.IsDead.Subscribe((oldValue, isDead) =>
            {
                if(isDead)
                {
                    IDisposable disposable = _spawnEnemiesToRemoveReason[spawnedEnemy];
                    disposable.Dispose();

                    _spawnEnemiesToRemoveReason.Remove(spawnedEnemy);
                }
            });

            _spawnEnemiesToRemoveReason.Add(spawnedEnemy, removeReason);
        }
    }
}
