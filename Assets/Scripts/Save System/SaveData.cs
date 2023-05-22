namespace SaveSystem
{
    [System.Serializable]
    public class SaveData
    {
        public ItemSavedData[] PlayerItems = null;

        public SaveData()
        {
            PlayerItems = new ItemSavedData[0];
        }
    }
}