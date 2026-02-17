using Assets._Project.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.GameplayRandomSymbol
{
    public class GameplayRandomSymbolView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _textAI;
        [SerializeField] private TMP_Text _textPlayer;

        public void SetTextAI(string text) => _textAI.text = text;
        public void SetTextPlayer(string text) => _textPlayer.text = text;
    }
}
