using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _speed = 5;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-45, 45));
        _rigidbody2D.velocity = transform.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameManager.Lives--;
    }
}