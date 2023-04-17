using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class PowerupBase : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var ship = other.transform.root.GetComponent<Spaceship>();

            if (!ship || !Player.Instance.PlayerShip)
                return;

            OnPickedup(ship);
            Destroy(gameObject);
        }

        protected abstract void OnPickedup(Spaceship ship);
    }
}
