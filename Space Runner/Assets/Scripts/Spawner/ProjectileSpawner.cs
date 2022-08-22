using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawner
{
    [SerializeField] protected Transform[] _spawnPoints;
    [SerializeField] protected float _timeToSpawn;

    [Space(height:10)][SerializeField] protected Pool _pool;
    [SerializeField] private bool _canSpawn = true;

    private void OnDisable()
    {
        _canSpawn = false;
    }
    private void OnEnable()
    {
        _canSpawn = true;
    }

    private void Start()
    {
        Invoke(nameof(Count), _timeToSpawn);
    }

    protected void Count()
    {
        if(_canSpawn) SpawnProjectile();
        Invoke(nameof(Count), _timeToSpawn);
    }

    protected override void SpawnProjectile()
    {
        _pool.GetFreeElement(_spawnPoints[Random.Range(0, _spawnPoints.Length)].position);
    }
}