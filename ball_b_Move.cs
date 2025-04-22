using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_b_Move : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;

    Vector3 target = new Vector3(11, 1.7f, 0); // Vector3 클래스의 인스턴스 변수 target 선언
    Vector3 velo = Vector3.zero; // (0,0,0) 으로 속도를 0으로 가정 , new 가 붙지 않음

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vec1 = new Vector3(h, 0, v);
        rigid.AddForce(vec1, ForceMode.Impulse);


        if (Input.GetButtonDown("Jump"))
        {
            Vector3 vec = new Vector3(0, JumpPower, 0);
            rigid.AddForce(vec, ForceMode.Impulse);
        }

        else if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 vec = new Vector3(0, JumpPower, 0);
            rigid.AddForce(vec, ForceMode.Impulse);
        }


    }


}
