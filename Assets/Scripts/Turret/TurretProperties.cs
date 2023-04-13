using UnityEngine;

namespace SpaceShooter
{
    public enum TurretModeEnum
    {
        Primary,
        Secondary,
    }

    [CreateAssetMenu(menuName = "Space Shooter / Turret")]
    public sealed class TurretProperties : ScriptableObject
    {
        [SerializeField]
        private TurretModeEnum _mode;
        public TurretModeEnum Mode => _mode;

        [SerializeField]
        private GameObject _projectilePrefab;
        public GameObject ProjectilePrefab => _projectilePrefab;

        [SerializeField]
        private float _fireRate;
        public float FireRate => _fireRate;

        [SerializeField]
        private int _energyCost;
        public int EnergyCost => _energyCost;

        [SerializeField]
        private int _ammoCost;
        public int AmmoCost => _ammoCost;

        [SerializeField]
        private AudioClip _fireSoundEffect;
        public AudioClip FireSoundEffect => _fireSoundEffect;
    }
}
