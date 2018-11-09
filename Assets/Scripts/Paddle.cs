using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 3;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        var transformPosition = transform.position;
        transformPosition.x = 0;
        transform.position = transformPosition;
        if (Random.Range(0, 1) == 0)
            _rigidbody2D.velocity = transform.right * _speed;
        else
            _rigidbody2D.velocity = transform.right * 1 * _speed;
    }

    public void ReverseDirection()
    {
        _rigidbody2D.velocity = -_rigidbody2D.velocity;
    }
}