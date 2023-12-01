using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        // get the rigidbody component in order to apply a force
        rb = GetComponent<Rigidbody>();
        // add a force using impulse which is an instant one time force
        rb.AddForce(force, ForceMode.Impulse);
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

