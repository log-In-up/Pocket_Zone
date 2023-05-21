using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Spawn Data", menuName = "Game Data/Spawn/Spawn Characteristics", order = 0)]
    public sealed class EnemySpawnData : ScriptableObject
    {
        [field: SerializeField, Min(0)] public ulong UnitsCountToSpawn { get; private set; }
        [field: SerializeField] public List<EnemyData> Enemies { get; private set; }
    }
}