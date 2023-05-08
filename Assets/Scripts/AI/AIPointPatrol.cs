using UnityEngine;

namespace SpaceShooter
{
    public class AIPointPatrol : MonoBehaviour
    {
        [SerializeField]
        private float _radius;
        public float Radius => _radius;

        private static readonly Color _gizmosColor = new Color(1, 0, 0, 0.3f);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = AIPointPatrol._gizmosColor;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}
