using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Spaceship))]
    public class AiController : MonoBehaviour
    {
        public enum AiBehaviourEnum
        {
            None,
            Patrol,
        }

        [SerializeField]
        private AiBehaviourEnum _behaviour;

        [SerializeField]
        private AIPointPatrol _patrolPoint;

        [Range(0f, 1f)]
        [SerializeField]
        private float _linearSpeed;

        [Range(0f, 1f)]
        [SerializeField]
        private float _angularSpeed;

        [SerializeField]
        private float _newMoveTargetTimout;

        [SerializeField]
        private float _selectNewTargetTimeout;

        [SerializeField]
        private float _shootTimeout;

        [SerializeField]
        private float _evadeRayLength;

        private Spaceship _ship;

        private Vector3 _moveTarget;

        private Distructible _attackTarget;

        private const float MAX_TORQUE_ANGLE = 45;

        private Timer _randomizeTargetPositionTimer;

        private void Start()
        {
            _ship = GetComponent<Spaceship>();

            InitTimers();
        }

        private void Update()
        {
            TickTimers();
            UpdateAi();
        }

        private void UpdateAi()
        {
            if (_behaviour == AiBehaviourEnum.None)
                return;

            if (_behaviour == AiBehaviourEnum.Patrol)
                UpdateBehaviourPatrol();
        }

        private void UpdateBehaviourPatrol()
        {
            ActionFindNewMoveTarget();
            ActionOperateShip();
            ActionFindNewAttackTarget();
            ActionFire();
            ActionEvadeCollision();
        }

        private void ActionFindNewMoveTarget()
        {
            if (_behaviour == AiBehaviourEnum.Patrol)
            {
                if (_attackTarget != null)
                {
                    _moveTarget = _attackTarget.transform.position;
                }
                else
                {
                    if (_patrolPoint != null)
                    {
                        bool isInsidePatrolZone =
                            (_patrolPoint.transform.position - transform.position).sqrMagnitude < _patrolPoint.Radius * _patrolPoint.Radius;

                        if (isInsidePatrolZone == true)
                        {
                            if (_randomizeTargetPositionTimer.IsFinished)
                            {
                                _randomizeTargetPositionTimer.Start(_newMoveTargetTimout);
                                var newPoint = Random.onUnitSphere * _patrolPoint.Radius + _patrolPoint.transform.position;
                                _moveTarget = newPoint;
                            }
                        }
                        else
                        {
                            _moveTarget = _patrolPoint.transform.position;
                        }
                    }
                }
            }
        }

        private void ActionOperateShip()
        {
            _ship.ThrustControl = _linearSpeed;

            _ship.TorqueControl =
                AiController.ComputeAlignTorqueNormalized(_moveTarget, _ship.transform) * _angularSpeed;
        }

        private static float ComputeAlignTorqueNormalized(Vector3 targerPosition, Transform shipTransform)
        {
            var localTargetPosition = shipTransform.InverseTransformPoint(targerPosition);

            var angle = Vector3.SignedAngle(localTargetPosition, Vector3.up, Vector3.forward);
            angle = Mathf.Clamp(angle, -MAX_TORQUE_ANGLE, MAX_TORQUE_ANGLE) / MAX_TORQUE_ANGLE;

            return -angle;
        }

        private void ActionFindNewAttackTarget()
        {

        }

        private void ActionEvadeCollision()
        {
            if (Physics2D.Raycast(transform.position, transform.up, _evadeRayLength))
            {
                _moveTarget = transform.position + transform.right * 100;
            }
        }

        private void ActionFire()
        {

        }

        #region Timers

        private void InitTimers()
        {
            _randomizeTargetPositionTimer = new Timer(_newMoveTargetTimout);
        }

        private void TickTimers()
        {
            _randomizeTargetPositionTimer.Tick(Time.deltaTime);
        }

        private void SetPatrolBehaviour(AIPointPatrol patrolPoint)
        {
            _behaviour = AiBehaviourEnum.Patrol;
            _patrolPoint = patrolPoint;
        }

        #endregion

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawSphere(_moveTarget, 0.1f);
            Gizmos.DrawLine(transform.position, transform.position + transform.up * _evadeRayLength);
        }
    }
}
