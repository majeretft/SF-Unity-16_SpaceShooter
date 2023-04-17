using UnityEngine;

namespace SpaceShooter
{
    public class MovementController : MonoBehaviour
    {
        public enum ContolTypes
        {
            Keyboard,
            TouchScreen,
        }

        [SerializeField] private ContolTypes _currentControlType;
        [SerializeField] private VirtualJoystick _virtualJoystick;
        [SerializeField] private Spaceship _shaceShip;

        [SerializeField] private PointerClickHold _touchFirePrimary;
        [SerializeField] private PointerClickHold _touchFireSecondary;

        #region Unity Events

        private void Start()
        {
            if (Application.isEditor)
            {
                _virtualJoystick.gameObject.SetActive(_currentControlType != ContolTypes.Keyboard);
                _touchFirePrimary.gameObject.SetActive(_currentControlType != ContolTypes.Keyboard);
                _touchFireSecondary.gameObject.SetActive(_currentControlType != ContolTypes.Keyboard);
                
                return;
            }

            _currentControlType = Application.isMobilePlatform ? ContolTypes.TouchScreen : ContolTypes.Keyboard;
            _virtualJoystick.gameObject.SetActive(Application.isMobilePlatform);
            _touchFirePrimary.gameObject.SetActive(Application.isMobilePlatform);
            _touchFireSecondary.gameObject.SetActive(Application.isMobilePlatform);
        }

        private void Update()
        {
            if (_currentControlType == ContolTypes.Keyboard)
                OperateByKeyboard();


            if (_currentControlType == ContolTypes.TouchScreen)
                OperateByTouchScreen();
        }

        #endregion

        private void OperateByKeyboard()
        {
            if (!_shaceShip)
                return;

            var thrust = 0f;
            var torque = 0f;

            if (Input.GetKey(KeyCode.UpArrow))
                thrust = 1;

            if (Input.GetKey(KeyCode.DownArrow))
                thrust = -1;

            if (Input.GetKey(KeyCode.LeftArrow))
                torque = 1;

            if (Input.GetKey(KeyCode.RightArrow))
                torque = -1;

            if (Input.GetKey(KeyCode.Space))
                _shaceShip.Fire(TurretModeEnum.Primary);

            if (Input.GetKey(KeyCode.X))
                _shaceShip.Fire(TurretModeEnum.Secondary);

            _shaceShip.ThrustControl = thrust;
            _shaceShip.TorqueControl = torque;
        }

        private void OperateByTouchScreen()
        {
            if (!_shaceShip)
                return;

            var direction = _virtualJoystick.Value;

            // var dotUp = Vector2.Dot(_shaceShip.transform.up, direction);
            // var dotRight = Vector2.Dot(_shaceShip.transform.right, direction);

            // _shaceShip.ThrustControl = Mathf.Max(0, dotUp);
            // _shaceShip.TorqueControl = -dotRight;

            _shaceShip.ThrustControl = direction.y;
            _shaceShip.TorqueControl = -direction.x;

            if (_touchFirePrimary.IsHold)
                _shaceShip.Fire(TurretModeEnum.Primary);

            if (_touchFireSecondary.IsHold)
                _shaceShip.Fire(TurretModeEnum.Secondary);
        }

        public void SetTarget(Spaceship shaceShip)
        {
            _shaceShip = shaceShip;
        }
    }
}
