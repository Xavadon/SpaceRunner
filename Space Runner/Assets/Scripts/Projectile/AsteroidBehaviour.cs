using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PoolObject))]
public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private GameObject _destroyEffect;
    private Pool _destroyEffectPool;

    private void Start()
    {
        _destroyEffectPool = AsteroidDestroyEffectSingleton.singleton.GetComponent<Pool>();
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(_damage);
            GetComponent<PoolObject>().ReturnToPool();
            _destroyEffectPool.GetFreeElement(transform.position);
            //Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        }
    }
}
