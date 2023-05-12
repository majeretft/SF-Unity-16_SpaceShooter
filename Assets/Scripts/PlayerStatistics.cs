using UnityEngine;

namespace SpaceShooter
{
    public class PlayerStatistics
    {
        [field: SerializeField]
        public int Kills { get; set; }

        [field: SerializeField]
        public int Score { get; set; }

        [field: SerializeField]
        public int Time { get; set; }

        public void Reset() {
            Kills = 0;
            Score = 0;
            Time = 0;
        }
    }
}
