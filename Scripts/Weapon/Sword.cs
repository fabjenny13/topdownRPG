using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator animator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;


    [SerializeField] private GameObject slashEffectPrefab;
    [SerializeField] private Transform slashEffectSpawnPoint;
    [SerializeField] private GameObject weaponCollider;
    private bool flipSlashAnim = false;

    private GameObject slashEffect;
    private float slashAnimTime;
    private void Awake()
    {
        playerControls = new PlayerControls();
        animator = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();

        slashAnimTime = slashEffectPrefab.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack(); //this means i'm subscribing a method to this event
                                                               //so, if this event occurs, the method subscribed to it will be called.    
    }

    private void Update()
    {
        FollowMouseWithOffset();
    }
    void Attack()
    {
        weaponCollider.SetActive(true);
        animator.SetTrigger("Attack");
        slashEffect = Instantiate(slashEffectPrefab, slashEffectSpawnPoint.position, Quaternion.identity);
        if(flipSlashAnim)
        {
            slashEffect.GetComponent<SpriteRenderer>().flipX = true;
        }
        slashEffect.transform.parent = this.transform.parent;
        Destroy(slashEffect, slashAnimTime + 1.0f);
    }

    void FollowMouseWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        //float angle = (Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg);

        if(mousePos.x < playerScreenPoint.x)
        {
            //activeWeapon.transform.rotation = Quaternion.Euler(-180, 0, angle);
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
            flipSlashAnim = true;
        }
        else
        {
            //activeWeapon.transform.rotation = Quaternion.Euler(0, 0, -angle);
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            flipSlashAnim = false;
        }


    }

    void DoneWithAttackEvent()
    {
        weaponCollider.SetActive(false);
    }
}
