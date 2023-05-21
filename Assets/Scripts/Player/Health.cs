using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Health : MonoBehaviour, IDamaged
    {
        #region Editor Fields
        [SerializeField] private AnimatorController _animatorController = null;
        #endregion

        #region Fields
        private float _currentHealth, _maxHealth;
        private Slider _healthSlider = null;
        #endregion

        #region Properties
        public bool IsDead => _currentHealth <= 0.0f;
        #endregion

        #region Public Methods
        internal void Init(PlayerData playerData, Slider healthBar)
        {
            _currentHealth = _maxHealth = playerData.MaxHealth;
            _healthSlider = healthBar;

            _healthSlider.value = _currentHealth / _maxHealth;
        }
        #endregion

        #region Interface Realization
        public void ApplyDamage(float damage)
        {
            if (IsDead) return;

            _currentHealth -= damage;

            _healthSlider.value = _currentHealth / _maxHealth;

            if (IsDead)
            {
                _animatorController.SetIsDeadState(true);
            }
        }

        public bool CanBeDamaged() => !IsDead;
        #endregion
    }
}