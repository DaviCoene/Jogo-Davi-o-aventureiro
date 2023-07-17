using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    private Animator anim;
    public bool isJumping;
    public bool DoubleJump;
    bool fall;

    bool isBlowing;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
    }

    void move()
    {
        //resolução de bug do personagem
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;

        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0f)
            {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if (movement < 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (movement == 0){
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce ), ForceMode2D.Impulse);
                DoubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (DoubleJump || fall)
                {

                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    DoubleJump = false;
                    fall = false;
                }
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Spike")
        {
            GameControler.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Saw")
        {
            GameControler.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
            fall = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            isBlowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }
}
