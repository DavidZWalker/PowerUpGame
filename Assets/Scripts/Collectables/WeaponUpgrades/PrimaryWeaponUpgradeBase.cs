using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrimaryWeaponUpgradeBase : MonoBehaviour, IWeaponUpgrade
{
    public ParticleSystem particles;

    public abstract void Upgrade(StandardGun weapon);

    private BoxCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.GetComponentInChildren<IPrimaryWeapon>().acceptUpgrade(this);
            Destroy(gameObject);
        }
    }
}
