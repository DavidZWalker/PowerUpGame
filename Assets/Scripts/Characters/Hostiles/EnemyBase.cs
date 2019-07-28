using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    protected Rigidbody2D _rigidBody2D;
    protected Transform _target;
    //protected AudioSource _audioSource;

    public float movementSpeed = 5f;
    public int strength = 1;
    public float health = 1;

    public List<DropMap> dropTable;

    [System.Serializable]
    public struct DropMap
    {
        public GameObject prefab;
        public float probability;
    }

    //public AudioClip aliveSound;
    //public AudioClip killedSound;

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

    protected void DropItem()
    {
        float dropNumber = Random.Range(0, 100);

        float dropCounter = 0;
        foreach (var drop in dropTable)
        {
            dropCounter += drop.probability;
            if (dropCounter > dropNumber)
            {
                Instantiate(drop.prefab, gameObject.transform.position, Quaternion.identity);
                return;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        //_audioSource = GetComponent<AudioSource>();
        InternalStart();
    }

    // Update is called once per frame
    void Update()
    {
        InternalUpdate();
    }
}
