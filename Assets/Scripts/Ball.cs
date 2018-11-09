using UnityEngine;

public class Ball : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody2D;

    public float Speed { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        transform.localPosition = Vector3.zero;
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-45, 45));
        _rigidbody2D.velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}