using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPoolOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PoolObject>(out PoolObject poolObject))
        {
            poolObject.ReturnToPool();
        }
    }
}
