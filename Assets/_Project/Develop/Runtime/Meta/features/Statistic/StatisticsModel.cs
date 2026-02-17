using Assets._Project.Develop.Runtime.Utilities.DataManagment.Data;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Meta.features.Statistic
{
    public class StatisticsModel : IDataReader<StatisticsData>, IDataWriter<StatisticsData>
    {
        private ReactiveVariable<int> _winCount = new ReactiveVariable<int>();
        private ReactiveVariable<int> _defeatCount = new ReactiveVariable<int>();

        public StatisticsModel(StatisticsDataProvider statisticsDataProvider)
        {
            statisticsDataProvider.RegisterWriter(this);
            statisticsDataProvider.RegisterReader(this);
        }

        public IReadOnlyVariable<int> WinCount => _winCount;
        public IReadOnlyVariable<int> DefeatCount => _defeatCount;

        public void UpdateWin() => _winCount.Value++;
        public void UpdateDefeat() => _defeatCount.Value++;

        public void ReadFrom(StatisticsData data)
        {
            _winCount.Value = data.WinCount;
            _defeatCount.Value = data.DefeatCount;
        }

        public void WriteTo(StatisticsData data)
        {
            data.WinCount = WinCount.Value;
            data.DefeatCount = DefeatCount.Value;
        }

    }
}
