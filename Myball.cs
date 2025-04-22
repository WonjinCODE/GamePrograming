using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myball : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;
    public float pushForce = 10f;

    MeshRenderer mesh;
    Material mat;
    int jumpCount;
    private bool isTurbo = false;
    public float moveSpeed = 1f;
    private bool Jump = false;
    




    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
 

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "tower")
        {
            rigid.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            mat.color = new Color(0, 0, 1); // 파란색
            Jump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "fance")
        {
            // 증심 좌표(0, 0, 0) 방향 벡터 계산 
            Vector3 directionToCenter = (Vector3.zero - transform.position).normalized;

            // 그 방향으로 힘 가하기
            rigid.AddForce(directionToCenter * pushForce, ForceMode.Impulse);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float speed = isTurbo ? moveSpeed * 2f : moveSpeed;

        Vector3 vec = new Vector3(h, 0, v);

        rigid.AddForce(vec * speed, ForceMode.Impulse);

        if (Input.GetButtonDown("Jump"))
        {
            jumpCount++;

            if (jumpCount == 2)
            {
                Vector3 vec2 = new Vector3(0, JumpPower, 0);
                rigid.AddForce(vec2, ForceMode.Impulse);
                
                jumpCount = 0; 
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            isTurbo = !isTurbo;
            Debug.Log("터보 모드 ON!");
        }

    }


}
