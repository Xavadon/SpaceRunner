using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileSpawner : ProjectileSpawner
{
    protected void Start()
    {
        _pool = BulletPoolSingleton.singleton.GetComponent<Pool>();
        Invoke(nameof(Count), _timeToSpawn);
    }
    protected override void SpawnProjectile()
    {
        var obj = _pool.GetFreeElement(transform.position);
        obj.GetComponent<Rigidbody2D>().velocity = (transform.up + Vector3.down) * 2;
    }
}
