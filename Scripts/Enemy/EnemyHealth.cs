using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health = 3.0f;
    private float knockThrust = 10.0f;
    private KnockBack knockback;
    private Flash flash;

    [SerializeField] private GameObject deathVFX;

    private void Awake()
    {
        knockback = gameObject.GetComponent<KnockBack>();
        flash = gameObject.GetComponent<Flash>();
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(flash.FlashRoutine());
        knockback.GetKnockedBack(FindObjectOfType<PlayerController>().transform, knockThrust);
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health <= 0.0f)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
