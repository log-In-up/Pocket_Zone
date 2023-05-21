using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class AIFighter : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private AnimatorController _animator = null;
        #endregion

        #region Fields
        private float _attackRadius, _damage, _delayBetweenAttacks, _currentDelay;
        private GameObject _player;
        #endregion

        #region MonoBehaviour API
        private void Update()
        {
            AttackTimer();

            AttackPlayer();
        }

        private void AttackPlayer()
        {
            if (_player == null) return;

            if (_currentDelay <= 0 && Vector3.Distance(transform.position, _player.transform.position) <= _attackRadius)
            {
                if (_player.TryGetComponent(out IDamaged damageable) && damageable.CanBeDamaged())
                {
                    damageable.ApplyDamage(_damage);

                    _animator.CallAttackTrigger();
                    _currentDelay = _delayBetweenAttacks;
                }
            }
        }
        #endregion

        #region Methods
        private void AttackTimer()
        {
            if (_currentDelay > 0)
            {
                _currentDelay -= Time.deltaTime;
            }
        }
        #endregion

        #region Public Methods
        internal void Init(float attackRadius, float damage, float delayBetweenAttacks)
        {
            _attackRadius = attackRadius;
            _damage = damage;
            _delayBetweenAttacks = delayBetweenAttacks;
            _currentDelay = 0.0f;
        }

        internal void SetChaisingPlayer(GameObject player)
        {
            _player = player != null ? player : null;
        }
        #endregion
    }
}