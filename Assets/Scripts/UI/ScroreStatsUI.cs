using TMPro;
using UnityEngine;

namespace SpaceShooter
{
    public class ScroreStatsUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        private int _lastScore;

        private void Update()
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            if (Player.Instance == null)
                return;

            var current = Player.Instance.Score;

            if (_lastScore != current) {
                _lastScore = current;
                _scoreText.text = $"Score: {_lastScore}";
            }
        }
    }
}
