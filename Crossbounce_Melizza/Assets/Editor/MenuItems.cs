using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Tools/Object Creator")]
    private static void ShowObstacleWindow()
    {
        ObstacleEditor.ShowWindow();
    }
}
