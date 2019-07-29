using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpreadUpgrade : PrimaryWeaponUpgradeBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Upgrade(StandardGun weapon)
    {
        weapon.bulletSpread /= 1.1f;
    }
}
