using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownUpgrade : PrimaryWeaponUpgradeBase
{
    public override void Upgrade(StandardGun weapon)
    {
        weapon.cooldownTime /= 1.1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
