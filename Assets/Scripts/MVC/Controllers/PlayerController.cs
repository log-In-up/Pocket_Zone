using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public sealed class PlayerController
    {
        #region Fields
        private readonly PlayerModel _playerModel;
        #endregion

        public PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        internal void MakeShot()
        {
            _playerModel.Shooting.MakeShot();
        }
    }
}