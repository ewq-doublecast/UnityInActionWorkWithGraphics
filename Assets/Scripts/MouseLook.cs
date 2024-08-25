using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField]
    private RotationAxes _rotationAxes = RotationAxes.MouseXAndY;

    [SerializeField]
    private float _sensitivityHorizontal = 6.0f;

    [SerializeField]
    private float _sensitivityVertical = 6.0f;

    [SerializeField]
    private float _minimumVertical = -89.0f;

    [SerializeField]
    private float _maximumVertical = 89.0f;

    private float _rotationX = 0;

    public void Update()
    {
        if (_rotationAxes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis(MouseX) * _sensitivityHorizontal, 0);
        }
        else if (_rotationAxes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis(MouseY) * _sensitivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVertical, _maximumVertical);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis(MouseY) * _sensitivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVertical, _maximumVertical);

            float delta = Input.GetAxis(MouseX) * _sensitivityHorizontal;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
