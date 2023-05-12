using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuController : SingletonBase<MainMenuController>
    {
        [SerializeField]
        private Spaceship _defaultSpaceShip;

        [SerializeField]
        private GameObject _shipSelection;

        [SerializeField]
        private GameObject _episodeSelection;

        private void Start()
        {
            LevelSequenceController.PlayerShip = _defaultSpaceShip;
        }

        public void OnButtonSelectShipClick()
        {
            _shipSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonStartClick()
        {
            _episodeSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonExitClick()
        {
            Application.Quit();
        }
    }
}
