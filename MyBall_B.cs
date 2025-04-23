using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall_B : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            // 2) 이동 입력 받기
            float h = Input.GetAxis("Horizontal_B");
            float v = Input.GetAxis("Vertical_B");

            Vector3 vec1 = new Vector3(h, 0, v);

            rigid.AddForce(vec1, ForceMode.Impulse);
        }

        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump_B"))
        {
            Vector3 vec2 = new Vector3(0, JumpPower, 0);
            rigid.AddForce(vec2, ForceMode.Impulse);
        }
    }
}
