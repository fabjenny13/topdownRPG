using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    enum State
    {
        Roaming
    }

    EnemyPathfinder enemyPathfinder;
    State state;

    private void Awake()
    {
        enemyPathfinder = GetComponent<EnemyPathfinder>();
        state = State.Roaming;  
    }
    void Start()
    {
        StartCoroutine(RoamingCoroutine());
    }
    Vector2 GenerateRoamingPosition()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }


    IEnumerator RoamingCoroutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamingPos = GenerateRoamingPosition();
            enemyPathfinder.MoveTo(roamingPos);
            yield return new WaitForSeconds(2f);
        }
    }
}

