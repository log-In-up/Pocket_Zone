using Enemies;
using GameData;
using UnityEngine;

namespace MVC
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class MVCMain : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private PlayerData _playerData = null;
        [SerializeField] private EnemySpawner _enemySpawner = null;
        [SerializeField] private Transform _entityHolder = null;
        #endregion

        #region Fields
        private InventoryController _inventoryController;
        private InventoryModel _inventoryModel;

        private PlayerController _playerController;
        private PlayerModel _playerModel;
        private PlayerCreator _playerlCreator;
        #endregion

        #region Properties
        public InventoryController InventoryController => _inventoryController;
        public InventoryModel InventoryModel => _inventoryModel;
        public PlayerController PlayerController => _playerController;
        public PlayerModel PlayerModel => _playerModel;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _inventoryModel = new InventoryModel();
            _inventoryController = new InventoryController(_inventoryModel);

            _playerModel = new PlayerModel();
            _playerlCreator = new PlayerCreator(_playerModel, _playerData);
            _playerController = new PlayerController(_playerModel);
        }

        private void Start()
        {
            _playerlCreator.Initialization(_entityHolder);
            _enemySpawner.Initialization(_entityHolder);
        }
        #endregion
    }
}