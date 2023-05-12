using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class PauseMenuPanel : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnPauseButtonClick()
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OnContinueButtonClick()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnMainMenuButtonClick()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneName);
        }
    }
}
