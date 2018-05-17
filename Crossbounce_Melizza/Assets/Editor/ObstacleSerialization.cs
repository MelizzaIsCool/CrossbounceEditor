using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*Class ObstacleFoldout makes the variabels in the ObstacleMovement class 
 * visible.
 * Help with OnInspectorGUI() and OnEnabled() from "softrare" on 
 * answers.unity.com from a question posed by "Ultramyth" on , Jan 02, 2014,
 * about EditorGUILayout use.
 **/

[CustomEditor(typeof(ObstacleMovement))]
public class ObstacleSerialization : Editor
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
        m_forwardMovement = m_object.FindProperty("moveToEndFirst");
        m_target = m_object.FindProperty("currentTarget");
        m_startPoint = m_object.FindProperty("startPoint");
        m_endPoint = m_object.FindProperty("endPoint");
        m_obstacleSpeed = m_object.FindProperty("obstacleSpeed");
    }

    public override void OnInspectorGUI()
    {
        m_staticObject.boolValue = EditorGUILayout.Toggle(new GUIContent("Moving Object", "If the obstacle uses its track system"), m_staticObject.boolValue);
        m_forwardMovement.boolValue = EditorGUILayout.Toggle(new GUIContent("Move To End First", " The object goes to the endpoint first on play"), m_forwardMovement.boolValue);
        EditorGUILayout.PropertyField(m_target);
        EditorGUILayout.PropertyField(m_startPoint);
        EditorGUILayout.PropertyField(m_endPoint);
        m_obstacleSpeed.floatValue = EditorGUILayout.FloatField(new GUIContent("Obstacle Speed"), m_obstacleSpeed.floatValue);
        m_object.ApplyModifiedProperties();
    }

}
