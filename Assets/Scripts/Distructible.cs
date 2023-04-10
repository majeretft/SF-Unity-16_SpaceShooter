using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Base class for all distructible entities
    /// </summary>
    public class Distructible : Entity
    {
        #region Properties

        /// <summary>
        /// Object can`t be destroyed
        /// </summary>
        [SerializeField]
        protected bool _isInvincible;

        /// <summary>
        /// Gets if object can`t be destroyed
        /// </summary>
        public bool IsInvincible => _isInvincible;

        /// <summary>
        /// Initial hit points amount
        /// </summary>
        [SerializeField]
        private int _initialHitPoints;

        /// <summary>
        /// Gets initial hit points amount
        /// </summary>
        public int InitialHitPoints => _initialHitPoints;

        /// <summary>
        /// Current hit points amount
        /// </summary>
        private int _hitPoints;

        /// <summary>
        /// Gets current hit points amount
        /// </summary>
        public int HitPoints => _hitPoints;

        [SerializeField]
        private UnityEvent _onDeathEvent;
        public UnityEvent OnDeathEvent => _onDeathEvent;
        #endregion

        #region Unity Events

        protected virtual void Start()
        {
            _hitPoints = _initialHitPoints;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Applies damage to current object
        /// </summary>
        /// <param name="damage">Damage to apply</param>
        public void ApplyDamage(int damage)
        {
            if (this.IsInvincible || damage < 0)
                return;

            _hitPoints -= damage;

            if (_hitPoints <= 0)
                HandleDistruction();
        }

        #endregion

        /// <summary>
        /// Fires when HP becomes less then 0
        /// </summary>
        protected virtual void HandleDistruction()
        {
            Destroy(this.gameObject);

            _onDeathEvent?.Invoke();
        }
    }
}
