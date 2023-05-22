using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Item List", menuName = "Game Data/Items/Item List", order = 0)]
    public sealed class ItemList : ScriptableObject
    {
        [field: SerializeField] public List<ItemData> GameItems { get; private set; }
    }
}
