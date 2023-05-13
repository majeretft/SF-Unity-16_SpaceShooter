using System.Linq;
using TMPro;
using UnityEngine;

namespace SpaceShooter
{
    public class AchievementsPanel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _kills;

        [SerializeField]
        private TextMeshProUGUI _score;

        [SerializeField]
        private TextMeshProUGUI _time;

        [SerializeField]
        private GameObject _mainMenuPanel;

        private bool _isSuccess;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void Start()
        {
            var levelResults = AggregateResults();

            _kills.text = $"Kills: {levelResults.Kills}";
            _score.text = $"Score: {levelResults.Score}";
            _time.text = $"Time: {levelResults.Time}";
        }

        private PlayerStatistics AggregateResults()
        {
            var result = LevelSequenceController.Instance.GameStats.Aggregate(
                new PlayerStatistics(),
                (acc, x) =>
                {
                    acc.Kills += x.Kills;
                    acc.Score += x.Score;
                    acc.Time += x.Time;

                    return acc;
                }
            );

            return result;
        }

        public void OnMainMenuButtonClick()
        {
            gameObject.SetActive(false);
            _mainMenuPanel.SetActive(true);
        }
    }
}
