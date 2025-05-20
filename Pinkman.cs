using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pinkman : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public float Score = 0;
    public TextMeshProUGUI ScoreText;
    private bool isGrounded = false;
    Rigidbody2D rigid;
    SpriteRenderer sprend;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt))
        {
            float h = Input.GetAxisRaw("Horizontal");

            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        }

        if(rigid.velocity.x > maxSpeed)         //오른쪽 이동
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }

        else if(rigid.velocity.x < -1 * maxSpeed)       //왼쪽 이동
        {
            rigid.velocity = new Vector2(-1 * maxSpeed, rigid.velocity.y);
        }
    }

    void Update()
    {

        if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt))
        {
            sprend.flipX = Input.GetAxisRaw("Horizontal") < 0;
        }

        if(rigid.velocity.normalized.x == 0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
           
        }

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            if (Score > 0)
            {
                Score--;
            }

            ScoreText.text = "Score: " + Score;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Score++;
            ScoreText.text = "Score: " + Score;
        }
    }
    
}
