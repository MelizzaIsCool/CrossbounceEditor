using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowObject : MonoBehaviour
{
    public GameObject myObject;
    Vector3 currentPosition;
    Vector3 lastPosition;

    private void Update()
    {
        currentPosition = transform.position;
        if(currentPosition != lastPosition)
        {
            myObject.transform.position += (0.5f *(currentPosition - lastPosition));
        }
        lastPosition = currentPosition;
    }

}
