using GameData;
using UnityEngine;
using Weapons;

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
        private Weapon _currentWeapon = null;
        private LayerMask _enemyLayer;
        private float _shootingRadius;

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
            if (_currentWeapon == null) return;

            _currentWeapon.UpdateTimer(Time.deltaTime);
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
            if (!_currentWeapon.CanShoot()) return;

            _animatorController.CallShootTrigger();

            if (_target != null && _target.TryGetComponent(out IDamaged damageable))
            {
                damageable.ApplyDamage(_currentWeapon.Damage);
            }

            _currentWeapon.SpendBullet();
            _currentWeapon.ResetTimer();
        }

        internal void Init(PlayerData playerData, Weapon weapon)
        {
            _shootingRadius = playerData.ShootingRadius;
            _enemyLayer = playerData.WhoIsEnemy;

            _currentWeapon = weapon;
        }
        #endregion
    }
}