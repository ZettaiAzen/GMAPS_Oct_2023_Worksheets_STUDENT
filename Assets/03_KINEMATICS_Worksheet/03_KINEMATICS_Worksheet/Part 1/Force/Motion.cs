using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        // velocity is calculated by displacement/time
        // to calculate displacement, velocity*time
        // dx = displacement in the x-axis, 3 = velocity, dt = time
        float dx = 3 * dt;
        float dy = 0;
        float dz = 0;

        transform.position = (new Vector3(transform.position.x + dx, transform.position.y + dy, transform.position.z + dz));
        
        Debug.Log(transform.position);

    }
}
