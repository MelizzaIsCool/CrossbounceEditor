using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowObject : MonoBehaviour
{

    private void Update()
    {
        Transform parent = GetComponentInParent<Transform>();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            parent.position = parent.position + Vector3.right;
        }
    }
}
