using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionScore : MonoBehaviour, ILevelCondition
    {
        [SerializeField]
        private int _requiredScore;

        private bool _isReached;

        public bool IsCompleted
        {

            get
            {
                if (Player.Instance != null && Player.Instance.PlayerShip != null && Player.Instance.Score >= _requiredScore)
                {
                    _isReached = true;
                }

                return _isReached;
            }
        }
    }
}
