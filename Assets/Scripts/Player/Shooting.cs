using Constants;
using GameData;
using UnityEngine;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Shooting : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private AnimatorController _animatorController = null;
        #endregion

        #region Fields
        private LayerMask _enemyLayer;
        private float _currentShootingDelay, _delayBetweenAttacks, _shootingRadius;
        private float _damage;
        private GameObject _target;
        #endregion

        #region MonoBehaviour API
        private void Update()
        {
            ShotTimer();

            TrackingPerEnemy();
        }
        #endregion

        #region Methods
        private void ShotTimer()
        {
            if (_currentShootingDelay > 0)
            {
                _currentShootingDelay -= Time.deltaTime;
            }
        }

        private void TrackingPerEnemy()
        {
            RaycastHit2D[] raycastHit2D = Physics2D.CircleCastAll(transform.position, _shootingRadius, Vector2.up, 0.01f, _enemyLayer);

            if (raycastHit2D.Length > 0)
            {
                float distance = float.PositiveInfinity;

                foreach (RaycastHit2D hit in raycastHit2D)
                {
                    if (hit.collider.TryGetComponent(out IDamaged damageable) && damageable.CanBeDamaged())
                    {
                        if (Vector2.Distance(transform.position, hit.collider.transform.position) < distance)
                        {
                            _target = hit.collider.gameObject;
                        }
                    }
                }
            }
            else
            {
                _target = null;
            }
        }
        #endregion

        #region Public Methods
        internal void MakeShot()
        {
            if (_currentShootingDelay > 0) return;

            _animatorController.CallShootTrigger();

            if (_target != null && _target.TryGetComponent(out IDamaged damageable))
            {
                damageable.ApplyDamage(_damage);
            }

            _currentShootingDelay = _delayBetweenAttacks;
        }

        internal void Init(PlayerData playerData)
        {
            _shootingRadius = playerData.ShootingRadius;
            _delayBetweenAttacks = playerData.DelayBetweenShots;
            _damage = playerData.Damage;
            _enemyLayer = playerData.WhoIsEnemy;

            _currentShootingDelay = 0.0f;
        }
        #endregion
    }
}