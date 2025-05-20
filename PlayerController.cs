using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    MeshRenderer mesh;
    public float JumpPower;
    public float Speed;
    public float Jumpcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector2 vec = new Vector2(h, v);

        //rigid.AddForce(vec, ForceMode2D.Impulse);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 vec2 = new Vector3(0, Speed, 0);
            rigid.AddForce(Vector2.left * Speed, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 vec2 = new Vector3(0, Speed, 0);
            rigid.AddForce(Vector2.right * Speed, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jumpcount++;
            if (Jumpcount == 1)
            {
                Vector2 vec2 = new Vector3(0, JumpPower, 0);
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                Jumpcount = 0;
            }
            


        }
    }
}

