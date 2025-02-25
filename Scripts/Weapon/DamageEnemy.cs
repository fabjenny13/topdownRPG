using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DamageEnemy : MonoBehaviour
{
    private float damageAmount = 1.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }
}
