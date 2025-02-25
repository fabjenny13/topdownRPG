using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinder : MonoBehaviour
{
    Vector2 moveDir;
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 0.5f;
    KnockBack knockback;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDir = new Vector2(0, 0);
        knockback = GetComponent<KnockBack>();
    }

    private void FixedUpdate()
    {
        if (!knockback.IsGettingKnocked())
        {
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);
        }
    }

    public void MoveTo(Vector2 nextPos)
    {
        moveDir = nextPos;
    }
}
