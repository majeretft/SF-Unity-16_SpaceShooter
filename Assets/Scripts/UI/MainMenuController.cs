using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _episodeSelection;

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
