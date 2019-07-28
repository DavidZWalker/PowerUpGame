using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ProjectileBase
{
    private Rigidbody2D _rigidbody2D;

    protected override void InternalStart()
    {
    }

    protected override void InternalUpdate()
    {
    }

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void Launch(Vector2 direction, float projectileSpeed)
    {
        _rigidbody2D.AddForce(direction * projectileSpeed);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
