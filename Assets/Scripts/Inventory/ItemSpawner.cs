using GameData;
using UnityEngine;

namespace Inventory
{
    public sealed class ItemSpawner
    {
        #region Fields
        private readonly ItemList _items;
        #endregion

        #region Properties
        public ItemList Items => _items;
        #endregion

        public ItemSpawner(ItemList items)
        {
            _items = items;
        }

        #region Public Methods
        internal void GenerateRandomDrop(Vector2 spawnPoint)
        {
            int index = Random.Range(0, _items.GameItems.Count);
            ItemData data = _items.GameItems[index];

            GameObject drop = Object.Instantiate(data.Model, spawnPoint, Quaternion.identity);

            drop.GetSafeComponent(out DropDataHolder dropData);
            dropData.Init(data);
        }
        #endregion
    }
}