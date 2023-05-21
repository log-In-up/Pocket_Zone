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
        #endregion

        #region Fields
        private float _currentHealth, _maxHealth;
        #endregion

        #region Properties
        private bool IsDead => _currentHealth <= 0.0f;
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
                _animator.SetIsDeadState(true);
                _healthSlider.gameObject.SetActive(false);
            }
        }

        public bool CanBeDamaged() => !IsDead;
        #endregion
    }
}