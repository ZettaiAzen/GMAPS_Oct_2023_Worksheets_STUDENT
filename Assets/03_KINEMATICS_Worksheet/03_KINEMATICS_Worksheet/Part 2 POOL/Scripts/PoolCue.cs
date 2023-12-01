using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        // when left mouse button is pressed,
        if (Input.GetMouseButton(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            // if there is a ball and the ball is not colliding with the mouse,
            if (ball != null && ball.IsCollidingWith(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) == false)
            {
                // draw a black line from the mouse to the ball
                drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 4, Color.black);
                drawnLine.EnableDrawing(true);
            }
        }
        // when the mouse button gets lifted up and there is a line,
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            // disable the line
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(ball.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ball.Velocity = v;

            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = ball.transform.position; // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
