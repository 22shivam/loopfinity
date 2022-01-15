using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static circularMotion;


public class generateArc : MonoBehaviour
{

    public float radius = 2.3f;
    public int segments = 50;
    public float range = 80;
    public float minArcWidth = 40;
    public float error = 0.3f;
    public ScoreManager sm;

    public GameObject arc;
    private LineRenderer lr;
public RetryButton retryButton;
public circularMotion cm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // line renderer give points to draw a line
        this.lr = arc.GetComponent<LineRenderer>();
        generateArcPoints();
        // arc.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // if mouse click
        if (Input.GetMouseButtonDown(0))
        {

            if (cm.getStop()) {
			cm.startCircle();
            retryButton.hideButton();
 			return; }
		          
            // generate new arc points
            // initial is first

            Vector3 initialArcPosition = lr.GetPosition(0);
            Vector3 finalArcPosition = lr.GetPosition(lr.positionCount - 1);
            Vector3 circleCenter = GameObject.FindGameObjectWithTag("Player").transform.position;
            
            // find max x and min x and max y and min y from lr.getposition
            float maxX = -100;
            float minX = 100;
            float maxY = -100;
            float minY = 100;
            for (int i=0; i<lr.positionCount; i++)
            {
                if (lr.GetPosition(i).x > maxX)
                {
                    maxX = lr.GetPosition(i).x;
                }
                if (lr.GetPosition(i).x < minX)
                {
                    minX = lr.GetPosition(i).x;
                }
                if (lr.GetPosition(i).y > maxY)
                {
                    maxY = lr.GetPosition(i).y;
                }
                if (lr.GetPosition(i).y < minY)
                {
                    minY = lr.GetPosition(i).y;
                }
            }

            if (circleCenter.x <= maxX + error && 
                circleCenter.x >= minX - error && 
                circleCenter.y <= maxY + error && 
                circleCenter.y >= minY - error)
            {
                generateArcPoints();
                sm.AddScore();
            }
            else
            {
            
                circularMotion circle = GameObject.FindGameObjectWithTag("Player").GetComponent<circularMotion>();
                circle.stopCircle();
                sm.ResetScore();

            }
            
            
            // if (initialArcPosition.x < finalArcPosition.x)
            // {
            //     if (initialArcPosition.y < finalArcPosition.y)
            //     {
            //         if (circleCenter.x >= initialArcPosition.x && circleCenter.x <= finalArcPosition.x && circleCenter.y >= initialArcPosition.y && circleCenter.y <= finalArcPosition.y)
            //         {
            //             generateArcPoints();
            //         }
            //     }
            //     else
            //     {
            //         if (circleCenter.x >= initialArcPosition.x && circleCenter.x <= finalArcPosition.x && circleCenter.y <= initialArcPosition.y && circleCenter.y >= finalArcPosition.y)
            //         {
            //             generateArcPoints();
            //         }
            //     }
            //
            // }
            // else
            // {
            //     if (initialArcPosition.y < finalArcPosition.y)
            //     {
            //         if (circleCenter.x <= initialArcPosition.x && circleCenter.x >= finalArcPosition.x && circleCenter.y >= initialArcPosition.y && circleCenter.y <= finalArcPosition.y)
            //         {
            //             generateArcPoints();
            //         }
            //     }
            //     else
            //     {
            //         if (circleCenter.x <= initialArcPosition.x && circleCenter.x >= finalArcPosition.x && circleCenter.y <= initialArcPosition.y && circleCenter.y >= finalArcPosition.y)
            //         {
            //             generateArcPoints();
            //         }
            //     }
            // }


            Debug.Log("x");
            Debug.Log(error);
            Debug.Log(minX - error);
            Debug.Log(circleCenter.x);
            Debug.Log(maxX + error);
            Debug.Log(circleCenter.x <= maxX && circleCenter.x >= minX);
            Debug.Log("y");
            Debug.Log(minY - error);
            Debug.Log(circleCenter.y);
            Debug.Log(maxY + error);
            Debug.Log(circleCenter.y <= maxY && circleCenter.y >= minY);

        }
        
    }

    UnityEngine.Vector3[] generateArcPoints()
    {
        UnityEngine.Vector3[]  arcPoints = new Vector3[segments + 1];
        // randomly generate start angle and end angle
        float startAngle = Random.Range(0, 360);
        float endAngle = Random.Range(startAngle + minArcWidth, startAngle + range);
        float angle = startAngle;
        float arcLength = endAngle - startAngle;
        
        
        for (int i = 0; i <= this.segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            arcPoints[i] = new Vector3(x, y, 0);

            angle += (arcLength / segments);
        }
        
        lr.startWidth = 1.5f;
        lr.endWidth = 1.5f;
        lr.positionCount = segments;
        lr.SetPositions(arcPoints);


        return arcPoints;
    }
}
