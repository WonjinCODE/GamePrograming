using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall_1 : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    Rigidbody rigid;
    
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        rigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "tower")
        {
            rigid.AddForce(Vector3.up, ForceMode.Impulse); // 점프
        }
        
    }


    private int collisionCount = 0; // 충돌 횟수 저장

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Myball") 
        {
            collisionCount++; 
            mat.color = new Color(1, 0, 0);
            Debug.Log("충돌하였습니다!! 현재까지 " + collisionCount + "회");
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.name == "Myball")
        {
            mat.color = new Color(1, 1, 0);
        }
    }
}
    