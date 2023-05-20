using MVC;
using UnityEngine;

namespace UserInterface
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public abstract class ScreenObserver : MonoBehaviour
    {
        #region Fields
        private bool _isOpened = default;
        private UICore _uiCore = null;
        private MVCMain _mvc = null;
        #endregion

        #region Properties
        public bool IsOpen => _isOpened;
        public UICore UICore => _uiCore;
        public MVCMain Mvc => _mvc;

        public abstract UIScreen Screen { get; }
        #endregion

        #region Virtual methods
        public virtual void Setup() { }

        public virtual void Activate()
        {
            _isOpened = true;
            gameObject.SetActive(_isOpened);
        }

        public virtual void Deactivate()
        {
            _isOpened = false;
            gameObject.SetActive(_isOpened);
        }
        #endregion

        #region Public methods
        public void SetScreenData(UICore uiCore, MVCMain mvcMain)
        {
            _uiCore = uiCore;
            _mvc = mvcMain;

            _isOpened = gameObject.activeInHierarchy;
        }
        #endregion
    }
}