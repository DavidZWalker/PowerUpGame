using UnityEngine;
using System.Collections;

public abstract class ProjectileBase : MonoBehaviour, IProjectile
{
    private float _timerHelper_projectileLife;

    public float projectileLife = 5f;
    public float power = 1;

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        InternalStart();
    }

    // Update is called once per frame
    void Update()
    {
        _timerHelper_projectileLife += Time.deltaTime;
        if (_timerHelper_projectileLife > projectileLife)
        {
            Destroy(gameObject);
            return;
        }

        InternalUpdate();
    }

    public abstract void Launch(Vector2 direction, float projectileSpeed);
    
    public abstract void OnCollisionEnter2D(Collision2D other);

    protected abstract void InternalStart();

    protected abstract void InternalUpdate();

    public virtual float GetPower()
    {
        return power;
    }
}
