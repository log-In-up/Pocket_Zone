using Constants;
using Pathfinding;
using UnityEngine;

namespace Enemies
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class AIView : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private AIDestinationSetter _destinationSetter = null;
        [SerializeField] private AIPath _aiPath = null;
        [SerializeField] private AIFighter _fighter = null;
        #endregion

        #region Fields
        private float _viewRadius;
        private GameObject _player;
        #endregion

        #region MonoBehaviour API
        private void Update()
        {
            TrackingPerPlayer();
        }
        #endregion

        #region Methods
        private void TrackingPerPlayer()
        {
            if (_player != null)
            {
                if (Vector2.Distance(transform.position, _player.transform.position) > _viewRadius)
                {
                    _player = null;

                    _destinationSetter.target = null;
                    _aiPath.isStopped = true;
                    _fighter.SetChaisingPlayer(null);
                }
            }
            else
            {
                RaycastHit2D hit2D = Physics2D.CircleCast(transform.position, _viewRadius, Vector2.up, 0.01f, LayerMask.NameToLayer(Tags.PLAYER));

                if (hit2D.collider != null)
                {
                    _player = hit2D.collider.gameObject;

                    if (_player.TryGetComponent(out IDamaged damageable) && damageable.CanBeDamaged())
                    {
                        _destinationSetter.target = _player.transform;
                        _aiPath.isStopped = false;

                        _fighter.SetChaisingPlayer(_player);
                    }
                }
            }
        }
        #endregion

        #region Public Methods
        internal void Init(float viewRadius) => _viewRadius = viewRadius;
        #endregion
    }
}