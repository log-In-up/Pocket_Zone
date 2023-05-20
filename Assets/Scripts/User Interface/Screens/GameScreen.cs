using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public sealed class GameScreen : ScreenObserver
    {
        #region Editor fields
        [SerializeField] private Button _attack = null;
        [SerializeField] private Button _inventory = null;
        [SerializeField] private Slider _healthBar = null;
        [SerializeField] private Joystick _joystick = null;
        #endregion

        #region Properties
        public override UIScreen Screen => UIScreen.Game;
        #endregion

        #region Overridden methods
        public override void Setup()
        {
            Mvc.PlayerModel.SetupHealthBar(_healthBar);
            Mvc.PlayerModel.SetupJoystick(_joystick);

            base.Setup();
        }

        public override void Activate()
        {
            _attack.onClick.AddListener(OnClickAttack);
            _inventory.onClick.AddListener(OnClickInventory);

            base.Activate();
        }

        public override void Deactivate()
        {
            _attack.onClick.RemoveListener(OnClickAttack);
            _inventory.onClick.RemoveListener(OnClickInventory);

            base.Deactivate();
        }
        #endregion

        #region Event handlers
        private void OnClickAttack() => Mvc.PlayerController.MakeShot();

        private void OnClickInventory() => UICore.OpenScreen(UIScreen.Inventory);
        #endregion
    }
}