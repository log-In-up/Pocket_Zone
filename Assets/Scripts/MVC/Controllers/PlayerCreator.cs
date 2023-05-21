using Constants;
using Player;
using UnityEngine;
using GameData;

namespace MVC
{
    public sealed class PlayerCreator
    {
        #region Fields
        private GameObject _playerGameObject;
        private readonly PlayerModel _playerModel;
        private readonly PlayerData _playerData;
        #endregion

        public PlayerCreator(PlayerModel playerModel, PlayerData playerData)
        {
            _playerModel = playerModel;
            _playerData = playerData;
        }

        #region Public Methods
        internal void Initialization(Transform entityHolder)
        {
            _playerGameObject = GameObject.FindGameObjectWithTag(Tags.PLAYER);

            if (_playerGameObject == null)
            {
                _playerGameObject = Object.Instantiate(_playerData.Model, Vector3.zero, Quaternion.identity);
            }

            _playerGameObject.transform.SetParent(entityHolder);

            _playerGameObject.GetSafeComponent(out Movement movement);
            movement.Init(_playerData, _playerModel.Joystick);

            _playerGameObject.GetSafeComponent(out Shooting shooting);
            _playerModel.SetupShooting(shooting);
            shooting.Init(_playerData);

            _playerGameObject.GetSafeComponent(out Health health);
            health.Init(_playerData, _playerModel.HealthBar);
        }
        #endregion
    }
}