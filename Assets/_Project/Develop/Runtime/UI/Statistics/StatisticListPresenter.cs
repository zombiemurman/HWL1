using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;


namespace Assets._Project.Develop.Runtime.UI.Statistics
{
    public class StatisticListPresenter : IPresenter
    {
        private readonly StatisticsModel _statistics;

        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly TextTextListView _iconTextListView;

        private readonly List<StatisticPresenter> _statisticPresenter = new();

        public StatisticListPresenter(
            StatisticsModel statistics, 
            ProjectPresentersFactory projectPresentersFactory, 
            ViewsFactory viewsFactory, 
            TextTextListView iconTextListView)
        {
            _statistics = statistics;
            _projectPresentersFactory = projectPresentersFactory;
            _viewsFactory = viewsFactory;
            _iconTextListView = iconTextListView;
        }

        public void Initialize()
        {
            Dictionary<string, IReadOnlyVariable<int>> Statistics = new Dictionary<string, IReadOnlyVariable<int>>()
            {
                {StatisticsKeys.Win, _statistics.WinCount },
                {StatisticsKeys.Defeat, _statistics.DefeatCount },
            };

            foreach (KeyValuePair<string, IReadOnlyVariable<int>> stat in Statistics)
            {
                TextTextView statisticView = _viewsFactory.Create<TextTextView>(ViewIDs.StatisticView);

                _iconTextListView.Add(statisticView);

                StatisticPresenter statisticPresenter = _projectPresentersFactory.CreateStatisticPresenter(stat.Key, stat.Value, statisticView);

                statisticPresenter.Initialize();

                _statisticPresenter.Add(statisticPresenter);
            }
        }

        public void Dispose()
        {
            foreach (StatisticPresenter statisticPresenter in _statisticPresenter)
            {
                _iconTextListView.Remove(statisticPresenter.View);
                _viewsFactory.Release(statisticPresenter.View);
                statisticPresenter.Dispose();
            }

            _statisticPresenter.Clear();
        }

  
    }
}
