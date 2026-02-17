using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;


namespace Assets._Project.Develop.Runtime.UI.Statistics
{
    public class StatisticPresenter : IPresenter
    {
        private readonly string _key;

        private readonly IReadOnlyVariable<int> _value;

        private readonly TextTextView _view;

        private IDisposable _disposable;

        public StatisticPresenter(string key, IReadOnlyVariable<int> value, TextTextView view)
        {
            _key = key;
            _value = value;
            _view = view;
        }

        public TextTextView View => _view;

        public void Initialize()
        {
            UpdateKey(_key);
            UpdateValue(_value.Value);

            _disposable = _value.Subscribe(OnValueChanged);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void UpdateValue(int value) => _view.SetTextValue(value.ToString());
        private void UpdateKey(string key) => _view.SetTextKey(key);

        private void OnValueChanged(int arg1, int newValue) => UpdateValue(newValue);

    }
}
