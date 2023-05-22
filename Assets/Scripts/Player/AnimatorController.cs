using UnityEngine;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class AnimatorController : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Animator _animator = null;
        #endregion

        #region Fields
        private const string IS_DEAD = "IsDead", ATTACK = "Attack", MOVEMENT = "Movement";
        #endregion

        #region Public Methods
        internal void SetIsDeadState(bool value) => _animator.SetBool(IS_DEAD, value);

        internal void SetMovement(float value) => _animator.SetFloat(MOVEMENT, value);

        internal void CallShootTrigger() => _animator.SetTrigger(ATTACK);
        #endregion
    }
}