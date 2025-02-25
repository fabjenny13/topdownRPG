using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathVFX : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if(ps && !ps.isPlaying)
        {
            DestroySelf();
        }
    }

    void DestroySelf()
    {
        Destroy(ps);
    }
}
