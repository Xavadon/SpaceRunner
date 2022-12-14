using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class BulletPoolSingleton : MonoBehaviour
{
    public static BulletPoolSingleton singleton { get; private set; }

    private void Awake()
    {
        singleton = this;
    }

}
