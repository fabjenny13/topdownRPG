using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    private float knockBackTime = 0.2f;
    private Rigidbody2D rb;
    private bool isGettingKnocked;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isGettingKnocked = false;
    }

    public void GetKnockedBack(Transform weaponTransform, float thrust)
    {
        if (!isGettingKnocked)
        {
            isGettingKnocked = true;
            Vector2 difference = (transform.position - weaponTransform.position).normalized * thrust * rb.mass;
            rb.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockedRoutine());
        }

    }

    public bool IsGettingKnocked()
    {
        return isGettingKnocked;
    }
    IEnumerator KnockedRoutine()
    {
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity = Vector2.zero;
        isGettingKnocked = false;

    }

}
