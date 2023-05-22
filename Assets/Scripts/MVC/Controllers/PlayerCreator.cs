using Constants;
using Player;
using UnityEngine;
using GameData;
using Weapons;
using Inventory;

namespace MVC
{
    public sealed class PlayerCreator
    {
        #region Fields
        private GameObject _playerGameObject;
        private readonly PlayerModel _playerModel;
        private readonly PlayerData _playerData;
        private readonly WeaponData _weaponData;
        #endregion

        public PlayerCreator(PlayerModel playerModel, PlayerData playerData, WeaponData weaponData)
        {
            _playerModel = playerModel;
            _playerData = playerData;
            _weaponData = weaponData;
        }

        #region Public Methods
        internal void Initialization(Transform entityHolder, InventoryController inventoryController, InventoryModel inventoryModel)
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
            Weapon weapon = new Weapon(_weaponData.DelayBetweenShots, _weaponData.Damage, inventoryModel);

            shooting.Init(_playerData, weapon);

            _playerGameObject.GetSafeComponent(out Health health);
            health.Init(_playerData, _playerModel.HealthBar);

            _playerGameObject.GetSafeComponent(out DropCollector collector);
            collector.Init(inventoryController);
        }
        #endregion
    }
}