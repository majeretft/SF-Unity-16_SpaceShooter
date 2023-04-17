using UnityEngine;

namespace SpaceShooter
{
    public class Player : SingletonBase<Player>
    {
        [SerializeField]
        private int _lifeCount;

        [SerializeField]
        private Spaceship _ship;
        public Spaceship PlayerShip => _ship;

        [SerializeField]
        private GameObject _shipPrefab;

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

            if (_lifeCount > 0)
                Respawn();
        }

        private void Respawn()
        {
            var wasExplodible = _ship.IsExplodible;

            var instance = Instantiate(_shipPrefab);

            _ship = instance.GetComponent<Spaceship>();
            _ship.IsExplodible = wasExplodible;

            _cameraController.SetTarget(instance.transform);
            _movementController.SetTarget(_ship);

            RegisterEvent();
        }
    }
}
