using GameData;
using UnityEngine;

namespace Inventory
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class DropDataHolder : MonoBehaviour
    {
        public bool Stackable { get; internal set; }
        public ulong ItemsInStack { get; internal set; }
        public Items ItemType { get; internal set; }
        public Sprite Icon { get; internal set; }

        #region Public Methods
        internal void Init(ItemData data)
        {
            Stackable = data.Stackable;
            ItemType = data.ItemType;
            Icon = data.Icon;
            ItemsInStack = data.ItemsInDrop;
        }
        #endregion
    }
}