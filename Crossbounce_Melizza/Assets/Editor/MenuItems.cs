using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Tools/Obstacle Creator")]
    private static void ShowObstacleWindow()
    {
        ObstacleEditor.ShowWindow();
    }
}
