using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Material defaultMat;
    public Material flashMat;

    private float flashTime = 0.2f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
    }
    

    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = defaultMat;
    }
}
