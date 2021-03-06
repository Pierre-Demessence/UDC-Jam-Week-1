﻿using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float Speed { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Reset()
    {
        var transformLocalPosition = transform.localPosition;
        transformLocalPosition.x = 0;
        transform.localPosition = transformLocalPosition;
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void Run()
    {
        if (Random.value > 0.5f)
            _rigidbody2D.velocity = transform.right * Speed;
        else
            _rigidbody2D.velocity = -transform.right * Speed;
    }

    public void ReverseDirection()
    {
        _rigidbody2D.velocity = -_rigidbody2D.velocity;
    }
}