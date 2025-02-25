using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerTransform;
    private float offset = -10.0f;

    
    void Update()
    {
        transform.position = playerTransform.position + new Vector3(0, 0, offset);
    }
}
