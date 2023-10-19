using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        //getting the total height because it is split into two (top and botton) from middle of camera
        // so need to multiply by 2
        GameHeight = Camera.main.orthographicSize * 2f;
        // the aspect shows the ratio of the width and the height of the screen so we need to multiply by the game height to get game width
        GameWidth = Camera.main.aspect * GameHeight;

        // initalising the range of the coordinates
        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0); //the position of the tail of the vector
        endPt = new Vector2(2, 3); //the head position of the head of the vector

        // calling the GetLine function from the lineFactory class to draw the vector
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        // drawnLine is using Line class. Calling the EnableDrawing function in the class to render the line
        drawnLine.EnableDrawing(true);

        //calculating the vector
        Vector2 vec2 = endPt - startPt;
        // printing out the magnitude of the vector in the console
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        // initialising the max range for X and Y coordinates
        //int maxX = 5;
        //int maxY = 5;

        // loop for the amount of times given in the argument in the function Question2b
        for (int i =0; i< n; i++)
        {
            //initialising the start point of the vector
            startPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            //initialising the end point of the vector
            endPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            //drawing the line using the GetLine function from the lineFactory class
            drawnLine = lineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black);

            //allows the line to be rendered
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        //drawing a red arrow from the tail being at 0,0,0 and head being 5,5,0 that stays for 60 seconds/ 1 min
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //making a new variable to store vector3 
            Vector3 endPtV3;

            // randomising the end point location /head of the vector
            endPtV3 = new Vector3(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY),
                // Z value is taken from max and min Y
                Random.Range(-maxY, maxY));
                
            Debug.Log(endPtV3);

            //drawing a white arrow from the origin to whatever the end point is that stays for 60 seconds/1 min
            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                endPtV3,
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;

        DebugExtension.DebugArrow(new Vector3(0, 0, 0), a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), c.ToUnityVector3(), Color.white, 60f);
        DebugExtension.DebugArrow(b.ToUnityVector3(), c.ToUnityVector3(), Color.white, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));

        DebugExtension.DebugArrow(a.ToUnityVector3(), (b*-1).ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), (a-b).ToUnityVector3(), Color.white, 60f);
    }

    public void Question3b()
    {
        // Your code here
        // ...

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
    }

    public void Question3c()
    {

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
