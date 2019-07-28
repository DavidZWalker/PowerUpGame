using UnityEngine;
using System.Collections;

public interface IEnemy
{
    void OnCollisionEnter2D(Collision2D other);

    void Kill();

    void Damage();
}
