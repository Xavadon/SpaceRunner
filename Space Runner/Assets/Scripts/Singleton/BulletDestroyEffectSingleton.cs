using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class BulletDestroyEffectSingleton : MonoBehaviour
{
    public static BulletDestroyEffectSingleton singleton { get; private set; }

    private void Awake()
    {
        singleton = this;
    }
}
