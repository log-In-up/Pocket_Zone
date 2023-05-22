using GameData;
using UnityEngine;

namespace Inventory
{
    public sealed class Item
    {
        #region Fields
        private bool _stackable;
        private ulong _itemsCount;

        private readonly Items _itemType;
        private readonly Sprite _image = null;
        #endregion

        #region Properties
        public bool Stackable => _stackable;
        public Items ItemType => _itemType;
        public Sprite Image => _image;
        public ulong ItemsCount => _itemsCount;
        #endregion

        public Item(Sprite image, Items itemType, ulong itemsCount, bool stackable)
        {
            _image = image;
            _itemType = itemType;
            _itemsCount = itemsCount;
            _stackable = stackable;
        }

        #region Public Methods
        public void AddAmount(ulong amount) => _itemsCount += amount;

        public void RemoveAmount(ulong amount) => _itemsCount -= amount;
        #endregion
    }
}