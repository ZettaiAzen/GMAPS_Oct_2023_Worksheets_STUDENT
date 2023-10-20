using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new Vector3 ((planet.position.x-rb.position.x), (planet.position.y-rb.position.y), 0);
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(planet.position + new Vector3(0, 1, 0), rb.position, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(planet.position, planet.position + new Vector3(0,1,0), Color.yellow);
        DebugExtension.DebugArrow(rb.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(rb.position, moveDir, Color.blue);

        
    }
}


