using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BackgroundElement : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField]
        private float _parallaxStrength;

        [SerializeField]
        private float _textureScale;

        private Material _quadMaterial;
        private Vector2 _offsetInitial;

        private void Start() {
            _quadMaterial = GetComponent<MeshRenderer>().material;
            _offsetInitial = Random.insideUnitCircle;

            _quadMaterial.mainTextureScale = Vector2.one * _textureScale;
        }

        private void Update() {
            var offset = _offsetInitial;

            offset.x = transform.position.x / transform.localScale.x / _parallaxStrength;
            offset.y = transform.position.y / transform.localScale.y / _parallaxStrength;

            _quadMaterial.mainTextureOffset = offset;
        }
    }
}
