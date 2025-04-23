using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Ball : MonoBehaviour
{
    public Rigidbody rigid;
    MeshRenderer mesh;
    Material mat;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube_tower")
        {
            Vector3 force = new Vector3(2f, 2f, -2f);
            rigid.AddForce(force, ForceMode.Impulse); // 순간적인 힘으로 이동!
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Otherball_Blue")
        {
            mat.color = new Color(1, 1, 1);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Otherball_Blue")
        {
            mat.color = new Color(1, 0, 0);
        }
    }

}