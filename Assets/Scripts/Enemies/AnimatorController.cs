using Pathfinding;
using UnityEngine;

namespace Enemies
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class AnimatorController : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Animator _animator = null;
        [SerializeField] private AIPath _aiPath = null;
        [SerializeField] private Transform _model = null;
        #endregion

        #region Fields
        private const string IS_DEAD = "IsDead", ATTACK = "Attack", MOVEMENT = "Movement";
        #endregion

        #region MonoBehaviour API
        private void Update()
        {
            if (_aiPath.velocity.x >= 0.01f)
            {
                _model.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (_aiPath.velocity.x <= -0.01f)
            {
                _model.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }

            _animator.SetFloat(MOVEMENT, _aiPath.velocity.magnitude);
        }
        #endregion

        #region Public Methods
        internal void SetIsDeadState(bool value) => _animator.SetBool(IS_DEAD, value);

        internal void CallAttackTrigger() => _animator.SetTrigger(ATTACK);
        #endregion
    }
}