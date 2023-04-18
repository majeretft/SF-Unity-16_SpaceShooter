using UnityEngine;

namespace SpaceShooter
{
    public class SpawnerDebris : MonoBehaviour
    {
        [SerializeField]
        private Distructible[] _debrisPrefabs;

        [SerializeField]
        private CircleArea _circleArea;

        [SerializeField]
        private int _debrisAmount;

        [SerializeField]
        private float _randomSpeed;

        private void Start()
        {
            for (int i = 0; i < _debrisAmount; i++)
            {
                SpawnDebris();
            }
        }

        private void SpawnDebris()
        {
            var index = Random.Range(0, _debrisPrefabs.Length);

            var instance = Instantiate(_debrisPrefabs[index]);

            instance.transform.position = _circleArea.GetRandomPointInsideArea();
            instance.OnDeathEvent.AddListener(OnDebrisDead);

            var rb = instance.transform.root.GetComponent<Rigidbody2D>();

            if (rb && _randomSpeed > 0)
                rb.velocity = Random.insideUnitCircle * _randomSpeed;
        }

        private void OnDebrisDead()
        {
            SpawnDebris();
        }
    }
}
