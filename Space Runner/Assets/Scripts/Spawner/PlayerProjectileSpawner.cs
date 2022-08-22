using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileSpawner : ProjectileSpawner
{
    protected override void SpawnProjectile()
    {
        var obj = _pool.GetFreeElement(transform.position);
        obj.GetComponent<Rigidbody2D>().velocity = transform.up * 2;
    }
}
