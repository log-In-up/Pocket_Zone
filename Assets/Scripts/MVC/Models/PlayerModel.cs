using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVC
{
    public sealed class PlayerModel
    {
        #region Fields
        private Shooting _shooting;
        private Slider _healthBar;
        private Joystick _joystick;
        #endregion

        #region Properties
        public Slider HealthBar => _healthBar;
        public Joystick Joystick => _joystick;
        public Shooting Shooting => _shooting;
        #endregion

        #region Public methods
        internal void SetupHealthBar(Slider healthBar) => _healthBar = healthBar;

        internal void SetupJoystick(Joystick joystick) => _joystick = joystick;

        internal void SetupShooting(Shooting shooting) => _shooting = shooting;
        #endregion
    }
}
