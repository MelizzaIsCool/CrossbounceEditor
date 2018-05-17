using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool movingObstacle = true;
    [Tooltip("Move to the end point on play")]
    public bool moveToEndFirst = true;
    public Transform currentTarget;
    public Transform startPoint;
    public Transform endPoint;
    public float obstacleSpeed = 5f;
    private Vector3 direction;
    private Transform tempPoint;

    private void Start()
    {
        //the target will be the endpoint on the games start
        currentTarget = endPoint;
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
            if (moveToEndFirst)
            {
                float step = obstacleSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);
                if(transform.position == endPoint.position)
                {
                    moveToEndFirst = false;
                }
            }
            //else if we're going backwards
            else
            {
                float step = obstacleSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, step);
                if (transform.position == startPoint.position)
                {
                    moveToEndFirst = true;
                }
            }
        }
	}
}
