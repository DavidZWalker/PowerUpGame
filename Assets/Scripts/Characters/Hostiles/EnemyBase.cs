using UnityEngine;
using System.Collections;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    protected Rigidbody2D _rigidBody2D;
    protected Transform _target;
    protected AudioSource _audioSource;

    public float movementSpeed = 5f;
    public int strength = 1;

    public float health = 1;

    public AudioClip aliveSound;
    public AudioClip killedSound;

    protected float Health
    {
        get
        {
            return health;
        }

        set
        {
            if (health != value)
            {
                health = value;
                //NotificationManager.Instance.New("Health: " + health);
                if (health <= 0)
                    Kill();
                else
                    Damage();
            }
        }
    }

    public abstract void Damage();

    public abstract void Kill();

    public abstract void OnCollisionEnter2D(Collision2D other);

    public abstract void OnTriggerEnter2D(Collider2D collider);

    protected abstract void InternalStart();

    protected abstract void InternalUpdate();

    // Use this for initialization
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        InternalStart();
    }

    // Update is called once per frame
    void Update()
    {
        InternalUpdate();
    }
}
