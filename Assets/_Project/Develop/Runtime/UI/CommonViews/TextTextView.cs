using Assets._Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.CommonViews
{
    public class TextTextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _textKey;

        [SerializeField] private TMP_Text _textValue;

        public void SetTextKey(string text) => _textKey.text = text;

        public void SetTextValue(string text) => _textValue.text = text;

        
    }
}
