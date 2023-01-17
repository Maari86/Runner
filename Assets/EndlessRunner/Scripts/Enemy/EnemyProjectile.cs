using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage //wiil damage the player every time the touch
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private bool hit;
    private BoxCollider2D coll;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision); //Execute logic from parent script first
        coll.enabled = false; //deactive while hits anything 

        if (anim != null)
            anim.SetTrigger("Explode"); //When the Object is fireball explode it
        else
            gameObject.SetActive(false); //When this hits anyobject deactivate the arrow

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
