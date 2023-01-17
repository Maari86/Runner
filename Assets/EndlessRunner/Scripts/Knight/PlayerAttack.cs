using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;
    [SerializeField] private AudioClip swordSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();
        if (Input.GetMouseButton(1) && cooldownTimer > attackCooldown && playerMovement.RageAttack())
     
            RageAttack();

        cooldownTimer += Time.deltaTime; 
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(swordSound);
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

    }

    private void RageAttack()
    {
        SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("RageAttack");
        cooldownTimer = 0;

        

      fireballs[FindFireball()].transform.position = firePoint.position;
      fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

      
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
