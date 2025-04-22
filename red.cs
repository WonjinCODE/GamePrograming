using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    Rigidbody rigid_red;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid_red = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vec = new Vector3(1, 0, 0);
        rigid_red.AddForce(vec, ForceMode.Impulse);
        Debug.Log(rigid_red.velocity);


    }


}
