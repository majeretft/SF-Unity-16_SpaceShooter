using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private int _lifeCount;

        [SerializeField]
        private Spaceship _ship;

        [SerializeField]
        private GameObject _shipPrefab;

        [SerializeField]
        private GameObject _explosionPrefab;

        [SerializeField]
        private CameraController _cameraController;

        [SerializeField]
        private MovementController _movementController;

        private void Start()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            _ship.OnDeathEvent.AddListener(OnDeath);
        }

        private void OnDeath()
        {
            _lifeCount--;

            GenerateExplosion();
        }

        private void Respawn()
        {
            if (_lifeCount <= 0)
                return;

            var instance = Instantiate(_shipPrefab);

            _ship = instance.GetComponent<Spaceship>();

            _cameraController.SetTarget(instance.transform);
            _movementController.SetTarget(_ship);

            RegisterEvent();
        }

        private void GenerateExplosion()
        {
            var instance = Instantiate(_explosionPrefab);
            var explosion = instance.GetComponent<Explosion>();
            explosion.SetTransform(transform.position, transform.rotation);

            explosion.ExplosionFinishedEvent.AddListener(Respawn);
        }
    }
}
