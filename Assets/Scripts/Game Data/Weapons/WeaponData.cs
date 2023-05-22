using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Weapon Characteristics", menuName = "Game Data/Weapon/Weapon Characteristics", order = 0)]
    public class WeaponData : ScriptableObject
    {
        [field: SerializeField, Min(0.0f)] public float Damage { get; private set; }

        [SerializeField, Min(0)] private ulong ShootsPerMinute;

        public float DelayBetweenShots => 60 / ShootsPerMinute;
    }
}