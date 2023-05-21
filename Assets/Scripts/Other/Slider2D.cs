using UnityEngine;

namespace Utility
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Slider2D : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private GameObject _slider = null;
        #endregion

        #region Fields
        private SpriteRenderer _sliderRenderer = null;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _sliderRenderer = _slider.GetComponent<SpriteRenderer>();
        }
        #endregion

        #region Public Methods
        public void SetSliderValue(float value)
        {
            Vector2 sliderSize = _sliderRenderer.size;
            sliderSize.x = value;

            float x = (value - 1.0f) / 2;

            _slider.transform.localPosition = new Vector3(x, 0.0f, 0.0f);
            _sliderRenderer.size = sliderSize;
        }
        #endregion
    }
}