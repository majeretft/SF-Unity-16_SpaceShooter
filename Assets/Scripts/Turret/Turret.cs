using UnityEngine;

namespace SpaceShooter
{
    public class Turret : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private TurretModeEnum _mode;
        public TurretModeEnum Mode => _mode;

        [SerializeField]
        private TurretProperties _properties;

        private float _fireTimer;

        public bool CanFire => _fireTimer < 0;

        private Spaceship _ship;
        #endregion

        #region Unity Events
        private void Start()
        {
            _ship = transform.root.GetComponent<Spaceship>();
        }

        private void Update()
        {
            if (_fireTimer > 0)
                _fireTimer -= Time.deltaTime;
        }
        #endregion

        #region Public API
        public void Fire()
        {
            if (!_properties || !CanFire)
                return;

            var projectile = Instantiate(_properties.ProjectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.up = transform.up;

            _fireTimer = _properties.FireRate;

            // TODO Sounds SFX
        }

        public void AssingProperties(TurretProperties props)
        {
            if (_mode != props.Mode)
                return;

            _fireTimer = 0;
            _properties = props;
        }
        #endregion
    }
}
