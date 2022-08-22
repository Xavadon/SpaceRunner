using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class AsteroidDestroyEffectSingleton : MonoBehaviour
{
    public static AsteroidDestroyEffectSingleton singleton { get; private set; }

    private void Awake()
    {
        singleton = this;
    }
}
