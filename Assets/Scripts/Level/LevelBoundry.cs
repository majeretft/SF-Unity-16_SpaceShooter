using UnityEditor;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundry : SingletonBase<LevelBoundry>
    {
        public enum BoundryEnum
        {
            Limit,
            Teleport,
        }

        [SerializeField]
        private float _radius;
        public float Raduis => _radius;

        [SerializeField]
        private BoundryEnum _limitMode;
        public BoundryEnum LimitMode => _limitMode;


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.color = Color.cyan;
            Handles.DrawWireDisc(transform.position, transform.forward, _radius);
        }
#endif
    }
}
