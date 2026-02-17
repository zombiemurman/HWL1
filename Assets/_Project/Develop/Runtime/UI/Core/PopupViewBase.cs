using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _mainGroup;
        [SerializeField] private CanvasGroup _body;
        [SerializeField] private Image _anticlicker;


        private void Awake()
        {
            _mainGroup.alpha = 0;
        }

        private void OnDestroy()
        {
            
        }

        public void OnCloseButtonClicked() => CloseRequest?.Invoke();

        public void Show()
        {
            OnPreShow();

            _mainGroup.alpha = 1;

            OnPostShow();
        }

        public void Hide()
        {
            OnPreHide();

            _mainGroup.alpha = 0;

            OnPostHide();
        }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreShow() { }

        protected virtual void OnPostHide() { }

        protected virtual void OnPreHide() { }

    }
}
