using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);
        moveDir = moveDir.Normalize() * -1f;

        rb.AddForce(moveDir.ToUnityVector3() * force);

        gravityNorm = gravityDir.Normalize();
        rb.AddForce(gravityNorm.ToUnityVector3() * gravityStrength);

        float angle = HVector2D.FindAngle(new HVector2D(planet.position.x, planet.position.y) + new HVector2D(0, 1), new HVector2D(rb.position.x, rb.position.y));
        Debug.Log(angle);
        rb.MoveRotation(Quaternion.Euler(0, 0, angle*Mathf.Rad2Deg));

        DebugExtension.DebugArrow(planet.position, planet.position + new Vector3(0, 1, 0), Color.yellow);
        DebugExtension.DebugArrow(rb.position, gravityDir.ToUnityVector3(), Color.red);
        DebugExtension.DebugArrow(rb.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
