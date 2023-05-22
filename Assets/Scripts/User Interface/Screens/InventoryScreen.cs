using System;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public sealed class InventoryScreen : ScreenObserver
    {
        #region Editor fields
        [SerializeField] private Button _close = null;
        [SerializeField] private Button _deleteItem = null;
        [SerializeField] private Transform _inventoryContent = null;
        [SerializeField] private GameObject _inventoryItem = null;
        #endregion

        #region Properties
        public override UIScreen Screen => UIScreen.Inventory;
        #endregion

        #region Overridden methods
        public override void Setup()
        {
            Mvc.InventoryModel.SetInventoryHolder(_inventoryContent);
            Mvc.InventoryModel.SetInventoryItemViewer(_inventoryItem);

            base.Setup();
        }

        public override void Activate()
        {
            _close.onClick.AddListener(OnClickCloseInventory);
            _deleteItem.onClick.AddListener(OnClickDeleteItem);

            Mvc.InventoryController.Activate();
            Mvc.InventoryController.OnSelect += OnSelect;

            base.Activate();
        }

        public override void Deactivate()
        {
            _close.onClick.RemoveListener(OnClickCloseInventory);
            _deleteItem.onClick.RemoveListener(OnClickDeleteItem);

            Mvc.InventoryController.OnSelect -= OnSelect;
            Mvc.InventoryController.Deactivate();

            base.Deactivate();
        }
        #endregion

        #region Event handlers
        private void OnClickCloseInventory() => UICore.OpenScreen(UIScreen.Game);

        private void OnClickDeleteItem()
        {
            Mvc.InventoryController.RemoveItem(Mvc.InventoryModel.SelectedItem);

            Mvc.InventoryController.Update();
            _deleteItem.gameObject.SetActive(false);
        }

        private void OnSelect()
        {
            _deleteItem.gameObject.SetActive(true);
        }
        #endregion
    }
}