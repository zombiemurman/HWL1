using Assets._Project.Develop.Runtime.Gameplay.Game;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Config
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/NewRigidbodyMovementConfig", fileName = "RigidbodyMovementConfig")]
    public class RigidbodyMovementConfig : ScriptableObject
    {
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}
