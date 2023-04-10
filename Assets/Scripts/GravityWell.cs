using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class GravityWell : MonoBehaviour
    {
        [SerializeField]
        private float _force;

        [SerializeField]
        private float _radius;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.attachedRigidbody)
                return;

            var dir = transform.position - other.transform.position;

            var dist = dir.magnitude;

            if (dist > _radius)
                return;

            var forceVector = dir.normalized * _force * _radius / dist;

            other.attachedRigidbody.AddForce(forceVector, ForceMode2D.Force);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetComponent<CircleCollider2D>().radius = _radius;
        }
#endif
    }
}
