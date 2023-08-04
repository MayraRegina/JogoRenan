using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador : MonoBehaviour
{
    public int health = 3;
    public float speed;
    public float jumpForce;
    
    
    private bool isJumping;
    private bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    private float movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        gamecontroller.instance.UpdateLives(health);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transicao",1);
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        } 

        if (movement < 0 )
        {
            if (!isJumping)
            {
                anim.SetInteger("transicao",1);   
            }
            
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if (movement == 0 && !isJumping)
        {
            anim.SetInteger("transicao", 0);
        }
        
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                anim.SetInteger("transicao",2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if(doubleJump)
                {
                    anim.SetInteger("transicao",2);
                    rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        gamecontroller.instance.UpdateLives(health);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isJumping = false;
        }

    }
}