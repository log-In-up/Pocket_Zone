using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Player Characteristics", menuName = "Game Data/Player Characteristics", order = 0)]
    public sealed class PlayerData : ScriptableObject
    {
        [field: SerializeField, Min(0.0f)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Min(0.0f)] public float SmoothTime { get; internal set; }
        [field: SerializeField, Min(0.0f)] public float MaxHealth { get; private set; }
        [field: SerializeField, Min(0.0f)] public float ShootingRadius { get; private set; }

        [SerializeField, Min(0)] private ulong ShootsPerMinute;

        public float DelayBetweenShots => 60 / ShootsPerMinute;
    }
}