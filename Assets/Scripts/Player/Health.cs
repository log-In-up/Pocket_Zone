using GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Health : MonoBehaviour, IDamaged
    {
        #region Fields
        private float _currentHealth, _maxHealth;
        private Slider _healthSlider = null;
        #endregion

        #region Public Methods
        public void ApplyDamage(float damage)
        {
            _currentHealth -= damage;

            _healthSlider.value = _currentHealth / _maxHealth;
        }

        internal void Init(PlayerData playerData, Slider healthBar)
        {
            _currentHealth = _maxHealth = playerData.MaxHealth;
            _healthSlider = healthBar;

            _healthSlider.value = _currentHealth / _maxHealth;
        }
        #endregion
    }
}