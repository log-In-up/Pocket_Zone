using UnityEngine;

namespace GameData
{
    public abstract class EnemyData : ScriptableObject
    {
        [field:Header("Model")]
        [field: SerializeField] public GameObject Model { get; private set; }
        [field: SerializeField] public LayerMask WhoIsEnemy { get; private set; }

        [field:Header("Characteristics")]
        [field: SerializeField, Min(0.0f)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Min(0.0f)] public float MaxHealth { get; private set; }
        [field: SerializeField, Min(0.0f)] public float Damage { get; private set; }
        [field: SerializeField, Min(0.0f)] public float AttackRadius { get; private set; }
        [field: SerializeField, Min(0.0f)] public float ViewRadius { get; private set; }

        [SerializeField, Min(0)] private ulong AttacksPerMinute;

        public float DelayBetweenAttacks => 60 / AttacksPerMinute;
    }
}