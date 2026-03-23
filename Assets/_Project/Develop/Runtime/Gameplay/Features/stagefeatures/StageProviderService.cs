using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures
{
    public class StageProviderService : IDisposable
    {
        private ReactiveVariable<int> _currentStageNumber = new();
        private ReactiveVariable<StageResults> _currentStageResult = new();

        private LevelConfig _levelConfig;

        private StageFactory _stageFactory;

        private IStage _currentStage;

        private IDisposable _stageEndedDisposable;

        public StageProviderService(LevelConfig levelConfig, StageFactory stageFactory)
        {
            _levelConfig = levelConfig;
            _stageFactory = stageFactory;
        }

        public IReadOnlyVariable<int> CurrentStageNumber => _currentStageNumber;

        public int StagesCount => _levelConfig.StageConfigs.Count;

        public IReadOnlyVariable<StageResults> CurrentStageResult => _currentStageResult;

        public LevelConfig LevelConfig => _levelConfig;

        public bool HasNextStage() => _currentStageNumber.Value < StagesCount;

        public void SwitchToNext()
        {
            if (HasNextStage() == false)
                throw new InvalidOperationException();

            if (_currentStage != null)
                CleanupCurrent();

            _currentStageNumber.Value++;

            _currentStageResult.Value = StageResults.Uncomplited;

            _currentStage = _stageFactory.Create(_levelConfig.StageConfigs[_currentStageNumber.Value - 1]);
        }

        public void StartCurrent()
        {
            _stageEndedDisposable = _currentStage.Completed.Subscribe(OnStageComplited);

            _currentStage.Start();
        }

        public void UpdateCurrent(float deltaTime) => _currentStage.Update(deltaTime);
        
        public void CleanupCurrent() => _currentStage.Cleanup();

        public void Dispose() 
        {
            _stageEndedDisposable?.Dispose();
            _currentStage?.Dispose();
        }

        private void OnStageComplited()
        {
            _currentStageResult.Value = StageResults.Complited;
        }
    }
}
