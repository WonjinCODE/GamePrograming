using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class else_ball : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube")
            rigid.AddForce(Vector3.up, ForceMode.Impulse); // 점프
    }
}
