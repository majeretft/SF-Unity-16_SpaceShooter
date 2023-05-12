using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        public static string MainMenuSceneName = "MainMenu";

        public Episode CurrentEpisode { get; private set; }

        public int CurrentLevel { get; private set; }

        public static Spaceship PlayerShip { get; set; }

        public bool IsLevelSuccess { get; private set; }

        public PlayerStatistics LevelStats { get; private set; }

        public void StartEpisode(Episode episode)
        {
            CurrentEpisode = episode;
            CurrentLevel = 0;

            LevelStats = new PlayerStatistics();
            LevelStats.Reset();

            SceneManager.LoadScene(episode.Levels[CurrentLevel]);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }

        public void FinishCurrentLevel(bool success)
        {
            IsLevelSuccess = success;
            CalculateLevelStats();

            ResultPanelController.Instance.ShowResults(LevelStats, IsLevelSuccess);
        }

        public void StartNextLevel()
        {
            LevelStats.Reset();

            CurrentLevel++;

            if (CurrentEpisode.Levels.Length <= CurrentLevel)
            {
                SceneManager.LoadScene(MainMenuSceneName);
            }
            else
            {
                SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
            }
        }

        private void CalculateLevelStats()
        {
            LevelStats.Score = Player.Instance.Score;
            LevelStats.Kills = Player.Instance.KillScore;
            LevelStats.Time = (int) LevelController.Instance.LevelTimer;
        }
    }
}
