using UnityEngine;

namespace SpaceShooter
{
    public class PowerupWeapon : PowerupBase
    {
        [SerializeField]
        private TurretProperties _properties;

        protected override void OnPickedup(Spaceship ship)
        {
            ship.AssignWeapon(_properties);
        }
    }
}
