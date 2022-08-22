using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private void Start()
    {
        _maxHealth = _currentHealth;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
        //effect
    }
}
