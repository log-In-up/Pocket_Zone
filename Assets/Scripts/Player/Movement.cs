using GameData;
using UnityEngine;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent, RequireComponent(typeof(Rigidbody2D))]
#endif
    public sealed class Movement : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Transform _model = null;
        [SerializeField] private AnimatorController _animatorController = null;
        #endregion

        #region Fields
        private Joystick _joystick;
        private PlayerData _playerData;
        private Rigidbody2D _rigidbody;
        private Vector3 _currentVelocity, _moveAmount;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + ((Vector2)transform.TransformDirection(_moveAmount) * Time.fixedDeltaTime));
        }
        #endregion

        #region Methods
        private void Move()
        {
            Vector3 moveDirection = new Vector3(_joystick.Horizontal, _joystick.Vertical, 0.0f).normalized;

            _moveAmount = Vector3.SmoothDamp(_moveAmount, moveDirection * _playerData.MovementSpeed, ref _currentVelocity, _playerData.SmoothTime);

            if (_moveAmount.x >= 0.01f)
            {
                _model.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (_moveAmount.x <= -0.01f)
            {
                _model.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }

            _animatorController.SetMovement(_moveAmount.magnitude);
        }
        #endregion

        #region Public Methods
        internal void Init(PlayerData playerData, Joystick joystick)
        {
            _playerData = playerData;
            _joystick = joystick;
        }
        #endregion
    }
}