using UnityEngine;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        public static string IgnoreTag = "WorldBoundry";

        [SerializeField]
        private float _speedDamageMultiplier;

        [SerializeField]
        private int _constantDamage;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var distructible = transform.root.GetComponent<Distructible>();

            if (!distructible)
                return;

            var damage = _constantDamage + (int)(_speedDamageMultiplier * other.relativeVelocity.magnitude);
            distructible.ApplyDamage(damage);
        }
    }
}
