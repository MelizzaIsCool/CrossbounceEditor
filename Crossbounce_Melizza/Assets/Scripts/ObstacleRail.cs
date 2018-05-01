using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRail : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Color railColor = Color.red;

    private ObstacleMovement rail;

    /// <summary>
    /// Finds the two end points to the obstacles path and draws a ray 
    /// between them.
    /// </summary>
    private void OnDrawGizmos()
    {
        rail = GetComponent<ObstacleMovement>();

        if (rail.movingObstacle)
        {
            startPoint.GetComponent<MeshRenderer>().enabled = true;
            endPoint.GetComponent<MeshRenderer>().enabled = true;
            Gizmos.color = railColor;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
        else
        {
            startPoint.GetComponent<MeshRenderer>().enabled = false;
            endPoint.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
