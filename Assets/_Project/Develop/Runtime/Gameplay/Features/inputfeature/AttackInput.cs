using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.inputfeature
{
    public class AttackInput : IInputService
    {
        public bool IsEnabled { get; set; } = true;

        public bool KeyAction => Input.GetKey(KeyCode.Space);

        public Vector3 Direction => Vector3.zero;
    }
}
