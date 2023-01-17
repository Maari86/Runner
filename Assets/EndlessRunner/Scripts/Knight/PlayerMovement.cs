using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask JumpableGround;

    private float dirX = 0f;
  
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float jumpForce = 0f;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;


    // Start is called before the first frame update

    private void Update()
    {
        GetPosition();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    public Vector2 GetPosition()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (dirX > 0.01f)
            transform.localScale = Vector3.one;
        else if (dirX < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();

            anim.SetBool("Moving", dirX != 0);
            anim.SetBool("Grounded", Grounded());
        }
        {
            return transform.position;
        }
           
    }



   private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("Jump");
        SoundManager.instance.PlaySound(jumpSound);
    }

   
    private bool Grounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, JumpableGround);

       return raycastHit.collider != null;
    }



   

  

    public bool canAttack()
    {
        return dirX == 0 && Grounded();
    }

    public bool RageAttack()
    {
        return dirX == 0 && Grounded();
    }


}

