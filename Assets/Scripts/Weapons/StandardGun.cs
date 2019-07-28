using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGun : PrimaryWeaponBase
{
    public override void acceptUpgrade(IWeaponUpgrade upgrade)
    {
        upgrade.Upgrade(this);
    }
}
