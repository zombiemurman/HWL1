using Assets._Project.Develop.Runtime.Utilities.DataManagment.Data;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;

namespace Assets._Project.Develop.Runtime.Meta.features.Statistic
{
    public class Statistics : IDataReader<StatisticsData>, IDataWriter<StatisticsData>
    {
        public Statistics(StatisticsDataProvider statisticsDataProvider)
        {
            statisticsDataProvider.RegisterWriter(this);
            statisticsDataProvider.RegisterReader(this);
        }

        public int WinCount { get; set; }
        public int DefeatCount { get; set; }

        public void UpdateWin() => WinCount++;
        public void UpdateDefeat() => DefeatCount++;

        public void ReadFrom(StatisticsData data)
        {
            WinCount = data.WinCount;
            DefeatCount = data.DefeatCount;
        }

        public void WriteTo(StatisticsData data)
        {
            data.WinCount = WinCount;
            data.DefeatCount = DefeatCount;
        }

    }
}
