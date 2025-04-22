using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour
{
    Rigidbody rigid_blue;

    // Start is called before the first frame update
    void Start()
    {
        rigid_blue = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rigid_blue.AddTorque(Vector3.back);


    }


}
