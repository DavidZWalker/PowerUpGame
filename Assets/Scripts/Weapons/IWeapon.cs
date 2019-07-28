using UnityEngine;
using System.Collections;

public interface IWeapon
{
    void Fire(Vector2 position, Vector2 direction);

    void acceptUpgrade(IWeaponUpgrade upgrade);
}
