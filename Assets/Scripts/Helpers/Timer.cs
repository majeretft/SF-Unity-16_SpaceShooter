namespace SpaceShooter
{
    public class Timer
    {
        private float _currentTime;

        public bool IsFinished => _currentTime <= 0;

        public Timer(float initialTime)
        {
            Start(initialTime);
        }

        public void Start(float initialTime)
        {
            _currentTime = initialTime;
        }

        public void Tick(float deltaTime)
        {
            if (_currentTime <= 0)
                return;

            _currentTime -= deltaTime;
        }
    }
}
