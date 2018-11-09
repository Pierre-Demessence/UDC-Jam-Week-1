using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private UnityEvent _onBallLost;

    private Rigidbody2D _rigidbody2D;

    public float Speed { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void Run()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-45, 45));
        _rigidbody2D.velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _onBallLost.Invoke();
    }
}