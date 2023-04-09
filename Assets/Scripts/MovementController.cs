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

        #region Unity Events

        private void Start()
        {
            if (Application.isEditor)
            {
                _virtualJoystick.gameObject.SetActive(_currentControlType != ContolTypes.Keyboard);
                return;
            }

            if (Application.isMobilePlatform)
            {
                _currentControlType = ContolTypes.TouchScreen;
                _virtualJoystick.gameObject.SetActive(true);
            }
            else
            {
                _currentControlType = ContolTypes.Keyboard;
                _virtualJoystick.gameObject.SetActive(false);
            }
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

            _shaceShip.ThrustControl = thrust;
            _shaceShip.TorqueControl = torque;
        }

        private void OperateByTouchScreen()
        {
            if (!_shaceShip)
                return;

            var direction = _virtualJoystick.Value;

            var dotUp = Vector2.Dot(_shaceShip.transform.up, direction);
            var dotRight = Vector2.Dot(_shaceShip.transform.right, direction);

            _shaceShip.ThrustControl = Mathf.Max(0, dotUp);
            _shaceShip.TorqueControl = -dotRight;
        }
    }
}
