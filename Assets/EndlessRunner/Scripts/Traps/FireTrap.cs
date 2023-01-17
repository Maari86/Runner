using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("FireTrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    [Header("SFX")]
    [SerializeField] private AudioClip firetrapSound;





    private bool triggered; //when the trap gets triggered
    private bool active; // trap is active and can hurt 
    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if(playerHealth != null && active)
        
            playerHealth.TakeDamage(damage);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        
            playerHealth = null;
    }
    private IEnumerator ActivateFiretrap()
    {
        //turn the sprite red 
        triggered = true;
        spriteRend.color = Color.red;

        //wait for delay
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(firetrapSound);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        //wait until X seconds
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
