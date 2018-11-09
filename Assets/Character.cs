using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCharacterHit;
    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded = false;

    public void Reset()
    {
        transform.localPosition = new Vector3(-4, -4, 0);
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (!_isGrounded) return;
        _rigidbody2D.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _onCharacterHit.Invoke();
    }
}