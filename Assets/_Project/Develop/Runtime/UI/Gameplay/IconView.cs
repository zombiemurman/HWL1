using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class IconView : MonoBehaviour, IView
    {
        [SerializeField] private Image _icon;

        public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
    }
}
