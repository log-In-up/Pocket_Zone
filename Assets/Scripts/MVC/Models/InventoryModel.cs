using GameData;
using Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public sealed class InventoryModel
    {
        #region Fields
        private Item _selectedItem = null;
        private List<Item> _playerItems = null;
        private Transform _inventoryContent = null;
        private GameObject _uiItem = null;
        #endregion

        #region Properties
        public Item SelectedItem => _selectedItem;
        public List<Item> PlayerItems => _playerItems;
        public Transform ContentHolder => _inventoryContent;
        public GameObject UiItem => _uiItem;
        #endregion

        public InventoryModel()
        {
            _playerItems = new List<Item>();
        }

        #region Public Methods
        internal void SetInventoryHolder(Transform inventoryContent) => _inventoryContent = inventoryContent;

        internal void SetInventoryItemViewer(GameObject uiItem) => _uiItem = uiItem;

        internal void SetSeletedItem(Item item) => _selectedItem = item;

        internal Item GetAmmoItem() => _playerItems.Find(x => x.ItemType.Equals(Items.Ammo5_45x39));

        internal bool CheckAvailability(Item item) => _playerItems.Contains(item);
        #endregion
    }
}
