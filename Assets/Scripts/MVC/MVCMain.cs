using Enemies;
using GameData;
using Inventory;
using SaveSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class MVCMain : MonoBehaviour, IDataPersistence
    {
        #region Editor fields
        [SerializeField] private PlayerData _playerData = null;
        [SerializeField] private WeaponData _weaponData = null;
        [SerializeField] private ItemList _itemList = null;
        [SerializeField] private EnemySpawner _enemySpawner = null;
        [SerializeField] private Transform _entityHolder = null;
        [SerializeField] private DataPersistenceManager _dataManager = null;
        #endregion

        #region Fields
        private ItemSpawner _itemSpawner = null;

        private InventoryController _inventoryController;
        private InventoryModel _inventoryModel;

        private PlayerController _playerController;
        private PlayerModel _playerModel;
        private PlayerCreator _playerCreator;
        #endregion

        #region Properties
        public InventoryController InventoryController => _inventoryController;
        public InventoryModel InventoryModel => _inventoryModel;
        public PlayerController PlayerController => _playerController;
        public PlayerModel PlayerModel => _playerModel;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _itemSpawner = new ItemSpawner(_itemList);

            _inventoryModel = new InventoryModel();
            _inventoryController = new InventoryController(_inventoryModel);

            _playerModel = new PlayerModel();
            _playerCreator = new PlayerCreator(_playerModel, _playerData, _weaponData);
            _playerController = new PlayerController(_playerModel);
        }

        private void Start()
        {
            _dataManager.LoadGame();

            _playerCreator.Initialization(_entityHolder, _inventoryController, _inventoryModel);
            _enemySpawner.Initialization(_entityHolder, _itemSpawner);
        }
        #endregion

        #region Public Methods
        internal void SaveGame()
        {
            _dataManager.SaveGame();
        }
        #endregion

        #region Interface Realization
        public void LoadData(SaveData data)
        {
            foreach (ItemSavedData itemSavedData in data.PlayerItems)
            {
                ItemData itemData = _itemSpawner.Items.GameItems.Find(x => x.ItemType.Equals(itemSavedData.ItemType));

                Item item = new Item(itemData.Icon, itemData.ItemType, itemSavedData.ItemsCount, itemData.Stackable);

                _inventoryController.AddItem(item);
            }
        }

        public void NewGame(SaveData data)
        {
            ItemData itemData = _itemSpawner.Items.GameItems.Find(x => x.ItemType.Equals(Items.Ammo5_45x39));
            Item item = new Item(itemData.Icon, itemData.ItemType, itemData.ItemsInDrop, itemData.Stackable);
            _inventoryModel.PlayerItems.Add(item);

            Array.Resize(ref data.PlayerItems, data.PlayerItems.Length + 1);
            data.PlayerItems[0] = new ItemSavedData(item.ItemType, item.ItemsCount);
        }

        public void SaveData(SaveData data)
        {
            List<ItemSavedData> playerItems = new List<ItemSavedData>();

            foreach (Item item in _inventoryModel.PlayerItems)
            {
                playerItems.Add(new ItemSavedData(item.ItemType, item.ItemsCount));
            }

            data.PlayerItems = playerItems.ToArray();
        }
        #endregion
    }
}