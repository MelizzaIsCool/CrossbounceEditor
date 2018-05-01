using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*Class ObstacleFoldout makes the variabels in the ObstacleMovement class 
 * visible through a dropdown.
 * Help with OnInspectorGUI() from "softrare" on answers.unity.com from a 
 * question posed by "Ultramyth" about EditorGUILayout.Foldout use, Jan 02, 2014
 **/

[CustomEditor(typeof(ObstacleMovement))]
public class ObstacleFoldout : Editor
{
    private bool showMovement;
    private SerializedObject m_object;
    private SerializedProperty m_staticObject;
    private SerializedProperty m_forwardMovement;
    private SerializedProperty m_target;
    private SerializedProperty m_startPoint;
    private SerializedProperty m_endPoint;
    private SerializedProperty m_obstacleSpeed;


    public void OnEnable()
    {
        m_object = new SerializedObject(target);
        m_staticObject = m_object.FindProperty("movingObstacle");
        m_forwardMovement = m_object.FindProperty("goingForward");
        m_target = m_object.FindProperty("currentTarget");
        m_startPoint = m_object.FindProperty("startPoint");
        m_endPoint = m_object.FindProperty("endPoint");
        m_obstacleSpeed = m_object.FindProperty("obstacleSpeed");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(m_staticObject);
        showMovement = EditorGUILayout.Foldout(showMovement, "Moving Object");        
        if (showMovement)
        {
            EditorGUILayout.PropertyField(m_forwardMovement);
            EditorGUILayout.PropertyField(m_target);
            EditorGUILayout.PropertyField(m_startPoint);
            EditorGUILayout.PropertyField(m_endPoint);
            EditorGUILayout.PropertyField(m_obstacleSpeed);
        }
    }

}
