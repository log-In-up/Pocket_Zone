using GameData;

namespace SaveSystem
{
    [System.Serializable]
    public class ItemSavedData
    {
        public Items ItemType;
        public ulong ItemsCount;

        public ItemSavedData(Items itemType, ulong itemsCount)
        {
            ItemType = itemType;
            ItemsCount = itemsCount;
        }
    }
}