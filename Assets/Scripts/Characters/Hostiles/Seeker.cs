using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Seekers can track the player from any distance and inflict damage by colliding with the player.
/// Slow and weak, they are the most basic enemy type
/// </summary>
public class Seeker : EnemyBase
{
    private bool _isDamaged;
    private float _timerHelper_betweenFlashes;
    private float _timeBetweenFlashes = 0.04f;
    private int _amountOfFlashes = 4;
    private int _flashHelper;
    private SpriteRenderer _sprite;
    private Color _spriteColor;

    public Color flashColor;
    public ParticleSystem bloodEffect;

    private bool IsDamaged
    {
        get
        {
            return _isDamaged;
        }

        set
        {
            _isDamaged = value;
            if (_isDamaged)
            {
                _flashHelper = _amountOfFlashes;
            }
        }
    }

    // Start is called before the first frame update
    protected override void InternalStart()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _spriteColor = _sprite.color;
        _flashHelper = _amountOfFlashes;
        _audioSource.clip = aliveSound;
        _audioSource.Play();
    }

    protected override void InternalUpdate()
    {
        // follow player
        SetTarget();
        _rigidBody2D.MovePosition(Vector2.MoveTowards(transform.position, _target.position, movementSpeed * Time.deltaTime));

        // flash when damaged
        if (IsDamaged)
        {
            if (_flashHelper >= 0)
            {
                _timerHelper_betweenFlashes += Time.deltaTime;
                if (_timerHelper_betweenFlashes >= _timeBetweenFlashes)
                {
                    _timerHelper_betweenFlashes = 0;
                    _sprite.color = _sprite.color == _spriteColor ? flashColor : _spriteColor;
                    _flashHelper--;
                }
            }
            else
            {
                IsDamaged = false;
                _flashHelper = _amountOfFlashes;
                _sprite.color = _spriteColor;
            }
        }
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        // collision with player
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Health = 0;
        }

        // collision with projectile
        var projectile = other.gameObject.GetComponent<IProjectile>();
        if (projectile != null)
        {
            //NotificationManager.Instance.New("Hit by bullet with power " + projectile.GetPower());
            Health -= projectile.GetPower();
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("trigger enter: " + collider.gameObject);

        // handle what happens when hit by explosive
        var projectile = collider.gameObject.GetComponent<IProjectile>();
        if (projectile != null)
        {
            Health -= projectile.GetPower();
        }
    }

    public override void Kill()
    {
        var blood = Instantiate(bloodEffect, transform.position, Quaternion.identity);
        blood.Play();
        Destroy(gameObject);
    }

    public override void Damage()
    {
        IsDamaged = true;
    }

    private void SetTarget()
    {
        var player = FindObjectOfType<PlayerController>();
        _target = player.transform;
    }
}
