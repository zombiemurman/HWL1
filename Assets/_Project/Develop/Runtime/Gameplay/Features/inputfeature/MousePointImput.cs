using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.inputfeature
{
    public class MousePointImput : IInputService
    {
        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                Vector3 direction = Vector3.zero;

                if (Input.GetMouseButtonDown(0))
                {
                    Camera camera = Camera.main;

                    if (IsPointerOverUI()) 
                        return Vector3.zero;

                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, Layers.GroundMask))
                    {
                        direction = hit.point;
                    }
                }

                return direction;
            }
        }

        bool IsPointerOverUI()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            return results.Count > 0;
        }
    }
}
