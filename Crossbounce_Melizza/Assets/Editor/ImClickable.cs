﻿using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class ImClickable : Editor
{
    public float bounciness;
    int changingValues = 1;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnEnable()
    {
        //if click on in the inspector, the scene view is also focused
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
    }

    private void OnSceneGUI()
    {
        Transform t = (Transform)target;
        Event currentEvent = Event.current;
        if (currentEvent.type == EventType.KeyDown)
        {
            if (currentEvent.isKey && currentEvent.keyCode == KeyCode.Alpha1)
            {
                changingValues = 2;
                //light the rotation, so user knows rotation is being changed
                Highlighter.Highlight("Inspector", "Local Rotation");
                Event.current.Use();
            }
            if (currentEvent.isKey && currentEvent.keyCode == KeyCode.Alpha2)
            {
                changingValues = 3;
                //highlight the position, so user knows position is being changed
                Highlighter.Highlight("Inspector", "Local Position");
                Event.current.Use();
            }

            if (currentEvent.isKey && currentEvent.keyCode == KeyCode.Alpha3)
            {
                changingValues = 1;
                //highlight the scale, so user knows scale is being changed
                Highlighter.Highlight("Inspector", "Local Scale");
                Event.current.Use();
            }

            //if user presses right arrow
            if (currentEvent.isKey && currentEvent.keyCode == KeyCode.RightArrow)
            {
                if (changingValues == 1)
                {
                    //scale positive in the X                   
                    t.localScale += new Vector3(0.1f, 0, 0);                                       
                }
                if (changingValues == 2)
                {
                    //rotation positive in the x
                    t.localEulerAngles += new Vector3(0, 0, 1f);
                }
                if (changingValues == 3)
                {
                    //move positive in the x
                    t.localPosition += new Vector3(0.1f, 0, 0);

                    if (Selection.activeGameObject.CompareTag("Track"))
                    {
                        Selection.activeGameObject.transform.parent.GetChild(0).transform.position += Vector3.right * 0.1f;
                            
                    }
                }
                Event.current.Use();

            }

            //if user presses left arrow
            if (currentEvent.isKey && currentEvent.keyCode == KeyCode.LeftArrow)
            {
                if (changingValues == 1)
                {
                    //scale negative in the x
                    t.localScale += new Vector3(-0.1f, 0, 0);
                }
                if (changingValues == 2)
                {
                    //rotate negative in the x
                    t.localEulerAngles += new Vector3(0, 0, -1f);
                }
                if (changingValues == 3)
                {
                    //move negative in the x
                    t.localPosition += new Vector3(-0.1f, 0, 0);
                    if (Selection.activeGameObject.CompareTag("Track"))
                    {
                        Selection.activeGameObject.transform.parent.GetChild(0).transform.position += Vector3.left * 0.1f;
                    }
                }
                Event.current.Use();
            }

            //if user presses up arrow
            if (currentEvent.isKey && currentEvent.keyCode == KeyCode.UpArrow)
            {
                if (changingValues == 1)
                {
                    //scale positive in the y
                    t.localScale += new Vector3(0, 0.1f, 0);
                }
                if (changingValues == 3)
                {
                    //move positive in the y
                    t.localPosition += new Vector3(0, 0.1f, 0);
                    if (Selection.activeGameObject.CompareTag("Track"))
                    {
                        Selection.activeGameObject.transform.parent.GetChild(0).transform.position += Vector3.up * 0.1f;
                    }
                }
                Event.current.Use();
            }

            //if user presses down arrow
            if (currentEvent.isKey && currentEvent.keyCode == KeyCode.DownArrow)
            {
                if (changingValues == 1)
                {
                    //scale negative in the y
                    t.localScale += new Vector3(0, -0.1f, 0);
                }
                if (changingValues == 3)
                {
                    //move negative in the y
                    t.localPosition += new Vector3(0, -0.1f, 0);
                    if (Selection.activeGameObject.CompareTag("Track"))
                    {
                        Selection.activeGameObject.transform.parent.GetChild(0).transform.position += Vector3.down * 0.1f;
                    }
                }
                Event.current.Use();
            }
        }
    }
}
