using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagSizeUpgrade : WeaponUpgradeBase
{
    public override void Upgrade(StandardGun weapon)
    {
        weapon.magSize++;
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
