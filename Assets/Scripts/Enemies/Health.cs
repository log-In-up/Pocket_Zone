using Pathfinding;
using UnityEngine;
using Utility;

namespace Enemies
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Health : MonoBehaviour, IDamaged
    {
        #region Editor Fields
        [SerializeField] private Slider2D _healthSlider = null;
        [SerializeField] private AnimatorController _animator = null;
        [SerializeField] private AIDestinationSetter _destinationSetter = null;
        [SerializeField] private AIPath _aiPath = null;
        [SerializeField] private AIFighter _fighter = null;
        #endregion

        #region Fields
        private float _currentHealth, _maxHealth;
        #endregion

        #region Properties
        public bool IsDead => _currentHealth <= 0.0f;
        #endregion

        #region Public Methods
        internal void Init(float maxHealth)
        {
            _currentHealth = _maxHealth = maxHealth;
            _healthSlider.SetSliderValue(_currentHealth / _maxHealth);
        }
        #endregion

        #region Interface Realization
        public void ApplyDamage(float damage)
        {
            if (IsDead) return;

            _currentHealth -= damage;

            _healthSlider.SetSliderValue(_currentHealth / _maxHealth);

            if (IsDead)
            {
                _destinationSetter.target = null;
                _aiPath.isStopped = true;
                _fighter.SetChaisingPlayer(null);

                _animator.SetIsDeadState(true);
                _healthSlider.gameObject.SetActive(false);
            }
        }

        public bool CanBeDamaged() => !IsDead;
        #endregion
    }
}