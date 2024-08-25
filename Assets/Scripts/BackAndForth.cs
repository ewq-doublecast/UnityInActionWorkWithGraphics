using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6.0f;

    [SerializeField]
    private float _minZ = -16.0f;

    [SerializeField]
    private float _maxZ = 16.0f;

    private int _direction = 1;

    private void Update()
    {
        transform.Translate(0, 0, _direction * _speed * Time.deltaTime);

        bool isBounced = false;

        if (transform.position.z > _maxZ ||  transform.position.z < _minZ)
        {
            _direction = -_direction;
            isBounced = true;
        }

        if (isBounced)
        {
            transform.Translate(0, 0, _direction * _speed * Time.deltaTime);
        }
    }
}
