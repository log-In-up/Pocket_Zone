using GameData;
using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class EnemySpawner : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private List<Transform> _spawnPoints = null;
        [SerializeField] private EnemySpawnData _spawnData = null;
        #endregion

        #region Public Methods
        internal void Initialization(Transform entityHolder)
        {
            for (ulong index = 0; index < _spawnData.UnitsCountToSpawn; index++)
            {
                int indexOfPoint = Random.Range(0, _spawnPoints.Count);
                Transform spawnPoint = _spawnPoints[indexOfPoint];

                int indexOfEnemy = Random.Range(0, _spawnData.Enemies.Count);
                EnemyData enemyData = _spawnData.Enemies[indexOfEnemy];

                GameObject enemy = Instantiate(enemyData.Model, spawnPoint.position, Quaternion.identity, entityHolder);

                enemy.GetSafeComponent(out Health health);
                health.Init(enemyData.MaxHealth);

                enemy.GetSafeComponent(out AIPath path);
                path.maxSpeed = enemyData.MovementSpeed;
                path.endReachedDistance = enemyData.AttackRadius;

                enemy.GetSafeComponent(out AIView view);
                view.Init(enemyData.ViewRadius);

                enemy.GetSafeComponent(out AIFighter fighter);
                fighter.Init(enemyData.AttackRadius, enemyData.Damage, enemyData.DelayBetweenAttacks);
            }
        }
        #endregion
    }
}