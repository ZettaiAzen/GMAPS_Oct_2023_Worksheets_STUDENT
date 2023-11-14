using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        float dx = 3 * dt;
        float dy = 0;
        float dz = 0;

        transform.position = (new Vector3(transform.position.x + dx, transform.position.y + dy, transform.position.z + dz));
        
        Debug.Log(transform.position);

    }
}
