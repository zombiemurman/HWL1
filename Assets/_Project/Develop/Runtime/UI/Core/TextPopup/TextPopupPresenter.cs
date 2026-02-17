using Assets._Project.Develop.Runtime.UI.Core.TestPopup;
using System;

namespace Assets._Project.Develop.Runtime.UI.Core.TextPopup
{
    public class TextPopupPresenter : PopupPresenterBase
    {
        private readonly TextPopupView _view;

        private string _text;

        public TextPopupPresenter(TextPopupView view, string text)
        {
            _view = view;
            _text = text;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetText(_text);
        }
    }
}
