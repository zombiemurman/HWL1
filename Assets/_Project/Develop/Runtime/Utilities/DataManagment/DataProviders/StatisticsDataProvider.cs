using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.Data;
using System;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders
{
    public class StatisticsDataProvider : DataProvider<StatisticsData>
    {
        public StatisticsDataProvider(ISaveLoadService saveLoadService) : base(saveLoadService)
        {
        }

        protected override StatisticsData GetOriginData()
        {
            return new StatisticsData()
            {
                WinCount = 0,
                DefeatCount = 0,
            };
        }
    }
}
