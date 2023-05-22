using Inventory;
using MVC;

namespace Weapons
{
    public sealed class Weapon
    {
        #region Fields
        private float _currentShootingDelay, _delayBetweenAttacks;

        private readonly float _damage;
        private readonly Item _ammo = null;
        private readonly InventoryModel _inventoryModel = null;
        #endregion

        #region Properties
        public float Damage => _damage;
        #endregion

        public Weapon(float delayBetweenAttacks, float damage, InventoryModel inventoryModel)
        {
            _damage = damage;
            _delayBetweenAttacks = delayBetweenAttacks;
            _inventoryModel = inventoryModel;
            _ammo = _inventoryModel.GetAmmoItem();

            _currentShootingDelay = 0.0f;
        }

        internal bool CanShoot()
        {
            if (_inventoryModel.CheckAvailability(_ammo))
            {
                return _currentShootingDelay <= 0 && _ammo.ItemsCount > 0;
            }
            return false;
        }

        internal void SpendBullet()
        {
            _ammo.RemoveAmount(1);
        }

        internal void ResetTimer()
        {
            _currentShootingDelay = _delayBetweenAttacks;
        }

        internal void UpdateTimer(float deltaTime)
        {
            if (_currentShootingDelay > 0)
            {
                _currentShootingDelay -= deltaTime;
            }
        }
    }
}