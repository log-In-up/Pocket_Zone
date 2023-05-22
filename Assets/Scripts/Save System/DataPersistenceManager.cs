using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaveSystem
{
    [DisallowMultipleComponent]
    public sealed class DataPersistenceManager : MonoBehaviour
    {
        #region Editor fields
        [Header("File Storage Config")]
        [SerializeField] private string _fileName;
        #endregion

        #region Fields
        private SaveData _gameData;
        private List<IDataPersistence> _dataPersistenceObjects;
        private FileDataHandler _dataHandler;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
            _dataPersistenceObjects = FindAllDataPersistenceObjects();
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
        #endregion

        #region Methods
        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
                .OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }
        #endregion

        #region Public methods
        public void LoadGame()
        {
            _gameData = _dataHandler.Load();

            if (_gameData == null)
            {
                NewGame();
            }

            foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(_gameData);
            }
        }

        public void NewGame()
        {
            _gameData = new SaveData();

            foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.NewGame(_gameData);
            }
        }

        public void SaveGame()
        {
            foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(_gameData);
            }

            _dataHandler.Save(_gameData);
        }
        #endregion
    }
}
