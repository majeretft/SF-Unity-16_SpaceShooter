using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class EpisodeSelectController : MonoBehaviour
    {
        [SerializeField]
        private Episode _episode;

        [SerializeField]
        private TextMeshProUGUI _episodeName;

        [SerializeField]
        private TextMeshProUGUI _episodeAbout;

        [SerializeField]
        private Image _previewImage;

        private void Start()
        {
            if (_episodeName)
                _episodeName.text = _episode.EpisodeName;

            if (_episodeName)
                _episodeAbout.text = _episode.EpisodeText;

            if (_previewImage)
                _previewImage.sprite = _episode.PreviewImage;
        }

        public void OnStartButtonClick()
        {
            LevelSequenceController.Instance.StartEpisode(_episode);
        }
    }
}
