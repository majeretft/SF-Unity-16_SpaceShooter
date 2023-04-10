using UnityEngine;

namespace SpaceShooter
{
    public class LevelBOundryLimiter : MonoBehaviour
    {
        private void Update()
        {
            if (!LevelBoundry.Instance)
                return;

            var lb = LevelBoundry.Instance;
            var r = lb.Raduis;

            if (transform.position.magnitude > r)
            {
                if (lb.LimitMode == LevelBoundry.BoundryEnum.Limit)
                {
                    transform.position = transform.position.normalized * r;
                }

                if (lb.LimitMode == LevelBoundry.BoundryEnum.Teleport)
                {
                    transform.position = -transform.position.normalized * r;
                }
            }
        }
    }
}
