using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class MouseRotationInput : IInputService
    {
        private const string HorizontalAxisName = "Mouse X";

        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                return new Vector3(Input.GetAxis("Mouse X"), 0, 0);
            }
        }

        public bool KeyAction => false;
    }
}
