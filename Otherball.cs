using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otherball : MonoBehaviour
{
    private Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "fance")
        {
            // Floor 중심 (0,0,0) 방향으로 힘 계산
            Vector3 directionToCenter = (Vector3.zero - transform.position).normalized;

            // 힘의 세기 설정
            float forcePower = 10f;

            // 순간적인 힘 적용
            rigid.AddForce(directionToCenter * forcePower, ForceMode.Impulse);

            
        }
    }
}
