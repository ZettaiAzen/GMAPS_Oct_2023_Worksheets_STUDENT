using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        //OtherPlayers = FindObjectsOfType<SoccerPlayer>();
        //SoccerPlayer[] temp = new SoccerPlayer[OtherPlayers.Length - 1];
        //int i = 0;
        //foreach (SoccerPlayer p in OtherPlayers)
        //{
        //    if (p != this)
        //    {
        //        temp[i] = p;
        //        i++;
        //    }
        //}
        //OtherPlayers = temp;
        //Debug.Log(OtherPlayers.Length);

        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();

        if (IsCaptain)
        {
            FindMinimum();
        }
    }

    void FindMinimum()
    {
        float lowestHeight = 21f;
        for(int i=0; i<10; i++)
        {
            float height = Random.Range(5f, 20f);
            Debug.Log(height);

            if(height < lowestHeight)
            {
                lowestHeight = height;
            }
        }
        Debug.Log("Lowest Height: " + lowestHeight);
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for (int i =0; i< OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - this.transform.position;
            toPlayer = Normalise(toPlayer);

            float dot = Dot(this.transform.forward, toPlayer);
            float angle = Mathf.Acos(dot);
            angle = angle *  Mathf.Rad2Deg;

            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        return closest;

    }

    float Magnitude(Vector3 vector)
    {
        return vector.magnitude;
    }

    Vector3 Normalise(Vector3 vector)
    {
        return vector.normalized;
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return Vector3.Dot(vectorA, vectorB);
    }


    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.black);
        }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);


            // DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


