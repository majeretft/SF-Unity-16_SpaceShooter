using UnityEngine;

namespace SpaceShooter
{
    public class PowerupStats : PowerupBase
    {
        public enum EffectTypeEnum
        {
            AddAmmo,
            AddEnergy,
        }

        [SerializeField]
        private EffectTypeEnum _effectType;

        [SerializeField]
        private int _value;

        protected override void OnPickedup(Spaceship ship)
        {
            if (_effectType == EffectTypeEnum.AddEnergy)
                ship.AddEnergy(_value);

            if (_effectType == EffectTypeEnum.AddAmmo)
                ship.AddAmmo(_value);
        }
    }
}
