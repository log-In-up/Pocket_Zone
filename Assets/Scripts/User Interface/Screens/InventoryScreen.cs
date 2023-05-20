using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public sealed class InventoryScreen : ScreenObserver
    {
        #region Editor fields
        [SerializeField] private Button _close = null;
        #endregion

        #region Properties
        public override UIScreen Screen => UIScreen.Inventory;
        #endregion

        #region Overridden methods
        public override void Setup()
        {

            base.Setup();
        }

        public override void Activate()
        {
            _close.onClick.AddListener(OnClickCloseInventory);

            base.Activate();
        }

        public override void Deactivate()
        {
            _close.onClick.RemoveListener(OnClickCloseInventory);

            base.Deactivate();
        }
        #endregion

        #region Event handlers
        private void OnClickCloseInventory() => UICore.OpenScreen(UIScreen.Game);
        #endregion
    }
}