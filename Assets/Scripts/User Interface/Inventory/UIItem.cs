using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
#if UNITY_EDITOR
    [DisallowMultipleComponent, RequireComponent(typeof(Button))]
#endif
    public sealed class UIItem : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Image _icon = null;
        [SerializeField] private TextMeshProUGUI _count = null;
        #endregion

        #region Fields
        private Item _item = null;
        private Button _button;
        #endregion

        #region Event
        public delegate void ButtonDelegate(Item item);
        public event ButtonDelegate OnClick;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClickButton);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickButton);
        }
        #endregion

        #region Event Handlers
        private void OnClickButton() => OnClick?.Invoke(_item);
        #endregion

        #region Public Methods
        internal void SetItemData(Item item)
        {
            _item = item;
            _icon.sprite = item.Image;

            if (item.ItemsCount > 1)
            {
                if (!_count.isActiveAndEnabled)
                {
                    _count.gameObject.SetActive(true);
                }
                _count.text = $"x {item.ItemsCount}";
            }
            else
            {
                _count.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}