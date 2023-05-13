using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class PlayerShipSelectionController : MonoBehaviour
    {
        [SerializeField] private Spaceship _prefab;

        [SerializeField] private TextMeshProUGUI _shipname;
        [SerializeField] private TextMeshProUGUI _hitpoints;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _agility;

        [SerializeField] private Image _preview;

        private void Start()
        {
            AssignTextValues();
        }

        private void AssignTextValues()
        {
            if (!_prefab)
                return;

            _shipname.text = _prefab.InteractiveName;
            _hitpoints.text = $"Hit points {_prefab.InitialHitPoints}";
            _speed.text = $"Speed {_prefab.SpeedLinearMax}";
            _agility.text = $"Agility {_prefab.SpeedAngularMax}";
            _preview.sprite = _prefab.ShipImage;
        }

        public void OnSelectShip()
        {
            LevelSequenceController.PlayerShip = _prefab;

            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}
