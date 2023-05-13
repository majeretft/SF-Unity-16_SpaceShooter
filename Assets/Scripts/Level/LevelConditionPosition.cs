using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        [SerializeField]
        private Transform _requiredPosiiton;

        [Range(0f, 20f)]
        [SerializeField]
        private float _requiredPosiitonRadius;

        private bool _isReached;

        public bool IsCompleted
        {

            get
            {
                if (Player.Instance == null || Player.Instance.PlayerShip == null || _requiredPosiiton == null)
                    return _isReached;

                var playerPosition = Player.Instance.PlayerShip.transform;
                if ((_requiredPosiiton.position - playerPosition.position).magnitude <= _requiredPosiitonRadius)
                    _isReached = true;

                return _isReached;
            }
        }

        #if UNITY_EDITOR
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(_requiredPosiiton.position, _requiredPosiitonRadius);
        }
        #endif
    }
}
