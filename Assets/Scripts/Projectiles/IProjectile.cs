using UnityEngine;
using UnityEditor;

public interface IProjectile
{
    void Launch(Vector2 direction, float projectileSpeed);

    float GetPower();
}