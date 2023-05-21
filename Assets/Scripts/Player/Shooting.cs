using GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Shooting : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private Transform _shootingPoint = null;
        [SerializeField] private AnimatorController _animatorController = null;
        #endregion

        #region Fields
        private bool _canShoot;
        private float _shootingDelay;
        private PlayerData _playerData = null;
        #endregion

        #region MonoBehaviour API
        private void Update()
        {
            if (_canShoot) return;

            if(_shootingDelay > 0)
            {
                _shootingDelay -= Time.deltaTime;
            }
            else
            {
                _shootingDelay = _playerData.DelayBetweenShots;
                _canShoot = true;
            }
        }
        #endregion

        #region Public Methods
        internal void MakeShot()
        {
            if (!_canShoot) return;

            _animatorController.CallShootTrigger();
            Debug.Log("Bang!");
        }

        internal void Init(PlayerData playerData)
        {
            _playerData = playerData;
        }
        #endregion
    }
}