using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Spaceship : Distructible
    {
        #region Fields

        /// <summary>
        /// Weight of space ship
        /// </summary>
        [Header("Space ship")]
        [SerializeField]
        private float _mass;

        /// <summary>
        /// Power of moving in forward direction
        /// </summary>
        [SerializeField]
        private float _thrust;

        /// <summary>
        /// Power of moving in radial direction
        /// </summary>
        [SerializeField]
        private float _torque;

        /// <summary>
        /// Max linear speed
        /// </summary>
        [SerializeField]
        private float _speedLinearMax;

        /// <summary>
        /// Max radial speed
        /// </summary>
        [SerializeField]
        private float _speedAngularMax;

        /// <summary>
        /// Reference to Rigit Body 2D
        /// </summary>
        private Rigidbody2D _rigidBodyComponent;

        /// <summary>
        /// Reference to Trail renderer
        /// </summary>
        private TrailRenderer _trailComponent;

        /// <summary>
        /// Ship weapons
        /// </summary>
        [SerializeField]
        private Turret[] _turrets;

        #endregion

        #region Public API

        /// <summary>
        /// Current linear thrust of main engine (from -1.0 to 1.0)
        /// </summary>
        /// <value></value>
        public float ThrustControl { get; set; }

        /// <summary>
        /// Current angular thrust of maneuver engine (from -1.0 to 1.0)
        /// </summary>
        /// <value></value>
        public float TorqueControl { get; set; }

        /// <summary>
        /// Fire selected weapons
        /// </summary>
        /// <param name="mode">Selected weapon</param>
        public void Fire(TurretModeEnum mode)
        {
            _turrets
                .Where(x => x.Mode == mode)
                .ToList()
                .ForEach(x => x.Fire());
        }

        #endregion

        #region Unity Events

        protected override void Start()
        {
            base.Start();

            _rigidBodyComponent = GetComponent<Rigidbody2D>();
            _rigidBodyComponent.mass = _mass;
            _rigidBodyComponent.inertia = 1;

            _trailComponent = GetComponentInChildren<TrailRenderer>();
            _trailComponent.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_trailComponent)
                _trailComponent.gameObject.SetActive(ThrustControl > 0);
        }

        private void FixedUpdate()
        {
            UpdateRigitBody();
        }

        #endregion

        /// <summary>
        /// Change thrust and torque of space ship
        /// </summary>
        private void UpdateRigitBody()
        {
            _rigidBodyComponent.AddForce(_thrust * ThrustControl * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);
            _rigidBodyComponent.AddForce(-_rigidBodyComponent.velocity * (_thrust / _speedLinearMax) * Time.fixedDeltaTime, ForceMode2D.Force);

            _rigidBodyComponent.AddTorque(_torque * TorqueControl * Time.fixedDeltaTime, ForceMode2D.Force);
            _rigidBodyComponent.AddTorque(-_rigidBodyComponent.angularVelocity * (_torque / _speedAngularMax) * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}
