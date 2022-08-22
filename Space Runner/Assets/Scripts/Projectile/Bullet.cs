using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(PoolObject))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _damage = 10;
    private Pool _destroyEffectPool;

    private void Start()
    {
        _destroyEffectPool = BulletDestroyEffectSingleton.singleton.GetComponent<Pool>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<AsteroidBehaviour>(out AsteroidBehaviour asteroidBehaviour))
        {
            DestroyBullet();
        }
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            DestroyBullet();
            damageable.ApplyDamage(_damage);
        }
    }

    private void DestroyBullet()
    {
        GetComponent<PoolObject>().ReturnToPool();
        _destroyEffectPool.GetFreeElement(transform.position);
    }
}
