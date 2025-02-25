using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private DeathVFX destroyVFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<DamageEnemy>())
        {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
