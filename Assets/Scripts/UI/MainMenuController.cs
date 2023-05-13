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

        [SerializeField]
        private GameObject _resultPanel;

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

        public void OnButtonAchievementsClick()
        {
            _resultPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonExitClick()
        {
            Application.Quit();
        }
    }
}
