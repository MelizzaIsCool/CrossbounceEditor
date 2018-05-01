using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [Header("Uncheck for stationary objects")]
    public bool movingObstacle = true;
    [Space]
    [Space]
    [Space]
    public bool goingForward = true;
    public Transform currentTarget;
    public Transform startPoint;
    public Transform endPoint;
    public float obstacleSpeed = 5f;

    private Vector3 startPosition;
    private Vector3 direction;
    private Transform tempPoint;

    private void Start()
    {
        //the target will be the endpoint on the games tart
        currentTarget = endPoint.transform;
        //turn off the mesh renderer of the end points
        startPoint.gameObject.GetComponent<MeshRenderer>().enabled = false;
        endPoint.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
        //if the obstacle is a moving one...
        if (movingObstacle)
        {
            //and we're going forward...
            if (goingForward)
            {
                //the obstacle should move until its center is within a certain distance from the targets center
                direction = currentTarget.GetComponent<Renderer>().bounds.center - transform.position;
                transform.Translate(direction.normalized * obstacleSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, endPoint.GetComponent<Renderer>().bounds.center) <= 0.1f)
                {
                    goingForward = false;
                    currentTarget = startPoint.transform;
                }
            }
            else
            {
                //Same as up top, just in the opposite direction
                direction = currentTarget.GetComponent<Renderer>().bounds.center - transform.position;
                transform.Translate(direction.normalized * obstacleSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startPoint.GetComponent<Renderer>().bounds.center) <= 0.2f)
                {
                    goingForward = true;
                    currentTarget = endPoint.transform;
                }
            }
        }
	}
}
