using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Item Characteristics", menuName = "Game Data/Items/Item Data", order = 0)]
    public sealed class ItemData : ScriptableObject
    {
        [field: Header("Characteristics")]
        [field: SerializeField] public bool Stackable { get; private set; }
        [field: SerializeField, Min(0)] public ulong ItemsInDrop { get; private set; }
        [field: SerializeField] public Items ItemType { get; private set; }
        [field: SerializeField] public GameObject Model { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}