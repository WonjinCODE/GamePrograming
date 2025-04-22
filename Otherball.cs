using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name ==
        "Myball") //
        {
            mat.color = new Color(0, 0, 0);
        }
    }
    private void OnCollisionExit(Collision collision) // 충돌 이벤트로부터 벗어나면 white
    {
        if (collision.gameObject.name == "Myball")
        {
            mat.color = new Color(1, 1, 1);
        }
    }
}
    