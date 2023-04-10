using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _interpolationLinear;

    [SerializeField]
    private float _interpolationAngular;

    [SerializeField]
    private float _offsetZ;

    [SerializeField]
    private float _offsetForward;

    private void FixedUpdate()
    {
        if (!_camera || !_target)
            return;

        var camPos = _camera.transform.position;
        var targetPos = _target.position + _target.up * _offsetForward;

        var newCamPos = Vector2.Lerp(camPos, targetPos, _interpolationLinear * Time.deltaTime);

        _camera.transform.position = new Vector3(newCamPos.x, newCamPos.y, _offsetZ);

        if (_interpolationAngular <= 0)
            return;

        _camera.transform.rotation =
            Quaternion.Slerp(_camera.transform.rotation, _target.rotation, _interpolationAngular * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
