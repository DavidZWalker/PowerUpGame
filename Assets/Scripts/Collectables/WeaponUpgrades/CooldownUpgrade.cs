using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownUpgrade : WeaponUpgradeBase
{
    public override void Upgrade(StandardGun weapon)
    {
        weapon.cooldownTime -= 0.1f;
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
