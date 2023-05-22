namespace SaveSystem
{
    public interface IDataPersistence
    {
        void LoadData(SaveData data);
        void NewGame(SaveData data);
        void SaveData(SaveData data);
    }
}