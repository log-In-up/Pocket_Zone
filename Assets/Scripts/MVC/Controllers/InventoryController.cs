using Inventory;
using System.Collections.Generic;
using UnityEngine;
using UserInterface;

namespace MVC
{
    public sealed class InventoryController
    {
        #region Fields
        private List<UIItem> _uiItems = null;
        private readonly InventoryModel _inventoryModel = null;
        #endregion

        #region Event
        public delegate void ButtonSelectionDelegate();
        public event ButtonSelectionDelegate OnSelect;
        #endregion

        public InventoryController(InventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
            _uiItems = new List<UIItem>();
        }

        #region Methods
        private void CreateItemsInUI()
        {
            foreach (Item item in _inventoryModel.PlayerItems)
            {
                GameObject uiItemGO = Object.Instantiate(_inventoryModel.UiItem, _inventoryModel.ContentHolder);

                uiItemGO.GetSafeComponent(out UIItem uiItem);
                _uiItems.Add(uiItem);
                uiItem.SetItemData(item);
            }

            foreach (UIItem item in _uiItems)
            {
                item.OnClick += SelectItem;
            }
        }

        private void DestroyItemsInUI()
        {
            foreach (UIItem item in _uiItems)
            {
                item.OnClick -= SelectItem;
            }
            _uiItems.Clear();

            foreach (Transform item in _inventoryModel.ContentHolder)
            {
                Object.Destroy(item.gameObject);
            }
        }
        #endregion

        #region Event Handlers
        private void SelectItem(Item item)
        {
            _inventoryModel.SetSeletedItem(item);
            OnSelect?.Invoke();
        }
        #endregion

        #region Public fields
        internal void Activate()
        {
            CreateItemsInUI();
        }

        internal void Update()
        {
            DestroyItemsInUI();

            CreateItemsInUI();
        }

        internal void Deactivate()
        {
            DestroyItemsInUI();
        }

        internal void AddItem(DropDataHolder itemData)
        {
            Item item = new Item(itemData.Icon, itemData.ItemType, itemData.ItemsInStack, itemData.Stackable);

            if (itemData.Stackable)
            {
                Item itemInInventory = _inventoryModel.PlayerItems.Find(x => x.ItemType == itemData.ItemType);

                if (itemInInventory != null)
                {
                    itemInInventory.AddAmount(item.ItemsCount);
                }
                else
                {
                    _inventoryModel.PlayerItems.Add(item);
                }
            }
            else
            {
                _inventoryModel.PlayerItems.Add(item);
            }
        }

        internal void AddItem(Item item)
        {
            if (item.Stackable)
            {
                Item itemInInventory = _inventoryModel.PlayerItems.Find(x => x.ItemType == item.ItemType);

                if (itemInInventory != null)
                {
                    itemInInventory.AddAmount(item.ItemsCount);
                }
                else
                {
                    _inventoryModel.PlayerItems.Add(item);
                }
            }
            else
            {
                _inventoryModel.PlayerItems.Add(item);
            }
        }

        internal void RemoveItem(Item item)
        {
            _inventoryModel.PlayerItems.Remove(item);
        }
        #endregion
    }
}