using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : ProjectileSpawner
{
    [Space(height:10)][SerializeField] private Pool _enemyPool;
    [SerializeField] private float _timeToSpawnEnemy = 4;

    protected override void SpawnProjectile()
    {
        var index = Random.Range(0, _spawnPoints.Length);
        _pool.GetFreeElement(_spawnPoints[index].position);
        if (index == 0)
        {
            SpawnEnemy(3, 90);
        }
        if (index == 3)
        {
            SpawnEnemy(0, -90);
        }
    }

    private void SpawnEnemy(int index, float rotation) 
    {
        var obj = _enemyPool.GetFreeElement(_spawnPoints[index].position);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
        obj.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
