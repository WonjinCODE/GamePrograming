using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall_A : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;
    int JumpCount;
    private bool isGrounded = false;
    int crushScore;
    MeshRenderer mesh;
    Material mat;
    private bool isSlow = false;
    public float moveSpeed = 1f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt))
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float speed = isSlow ? moveSpeed / 2f : moveSpeed;

            Vector3 vec = new Vector3(h, 0, v);

            rigid.AddForce(vec * speed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            isSlow = !isSlow;
            Debug.Log("슬로우모드 ON!");
        }

    }



    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Vector3 vec2 = new Vector3(0, JumpPower, 0);
            rigid.AddForce(vec2, ForceMode.Impulse);
            isGrounded = false;

        }
        if (rigid != null)
        {
            // 현재 속도 벡터를 가져와서 문자열로 변환해 출력
            Vector3 vel = rigid.velocity;
            Debug.Log($"Current Velocity: {vel}");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube_tower")
        {
            rigid.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            mat.color = new Color(0, 0, 1); // 들어가면 파란색
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cube_tower")
        {
            mat.color = new Color(1, 1, 1); // 나오면 흰색
        }
    }



    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }


            if (collision.gameObject.name == "Otherball_Blue")
            {
                crushScore += 2;
                Debug.Log("현재 점수: " + crushScore);

                if (crushScore > 4)
                {
                    mat.color = new Color(211, 211, 211); //Gray
                }

                if (crushScore == 10)
                {
                    Vector3 vec2 = new Vector3(0, JumpPower, 0);
                    rigid.AddForce(vec2, ForceMode.Impulse);
                }
            }

            if (collision.gameObject.name == "Otherball_Red")
            {
                crushScore -= 1;
                Debug.Log("현재 점수: " + crushScore);

                if (crushScore < 5)
                {
                    mat.color = new Color(0, 0, 0);
                }

            }



        }
    
}
