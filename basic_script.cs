using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_script : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;

   

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

        


    }


}
