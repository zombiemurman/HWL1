using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities
{
    public class Layers
    {
        public static readonly int Characters = LayerMask.NameToLayer("Characters");
        public static readonly LayerMask CharactersMask = 1 << Characters;

        public static readonly int Enemy = LayerMask.NameToLayer("Enemy");
        public static readonly LayerMask EnemyMask = 1 << Enemy;

        public static readonly int Ground = LayerMask.NameToLayer("Ground");
        public static readonly LayerMask GroundMask = 1 << Ground;

    }
}
