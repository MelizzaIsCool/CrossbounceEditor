using UnityEngine;
using UnityEditor;
using System.Text;

public class ObstacleEditor : EditorWindow
{
    private static ObstacleEditor instance;
    public float obstacleSpeed = 5.0f;

    public static void ShowWindow()
    {
        instance = EditorWindow.GetWindow<ObstacleEditor>();
        instance.titleContent = new GUIContent("Level Editor");
    }

    private void OnGUI()
    {
        obstacleSpeed = EditorGUILayout.FloatField("Obstacle Speed", obstacleSpeed, GUILayout.Width(200));
        if (obstacleSpeed > 15)
        {
            obstacleSpeed = 15;
        }
        if (GUILayout.Button("Create Obstacle", GUILayout.Width(150)))
        {
            //First fetch Guid assets
            string[] obstacleGuids = AssetDatabase.FindAssets("Obstacle System");
            StringBuilder guiBuilder = new StringBuilder();

            foreach (string obstacle in obstacleGuids)
            {
                guiBuilder.AppendLine(obstacle);
            }

            if (obstacleGuids.Length > 0)
            {
                string trueObstacleGuids = obstacleGuids[0];
                //get the assets oath from the guid
                string assetPath = AssetDatabase.GUIDToAssetPath(trueObstacleGuids);
                //Get the object itself
                GameObject wallTemp = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
                GameObject newWall = Instantiate(wallTemp);
                newWall.name = wallTemp.name;
                PhysicsMaterial2D physMat = new PhysicsMaterial2D();
                newWall.transform.GetChild(1).GetComponent<Collider2D>().sharedMaterial = physMat;
                newWall.transform.GetChild(1).GetComponent<ObstacleMovement>().obstacleSpeed = obstacleSpeed;
            }
        }


        if (GUILayout.Button("Create Target", GUILayout.Width(150)))
        {
            //First fetch Guid assets
            string[] obstacleGuids = AssetDatabase.FindAssets("prefab_Target");
            StringBuilder guiBuilder = new StringBuilder();

            foreach (string obstacle in obstacleGuids)
            {
                guiBuilder.AppendLine(obstacle);
            }

            if (obstacleGuids.Length > 0)
            {
                string trueObstacleGuids = obstacleGuids[0];
                //get the assets oath from the guid
                string assetPath = AssetDatabase.GUIDToAssetPath(trueObstacleGuids);
                //Get the object itself
                GameObject targetTemp = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
                GameObject newTarget = GameObject.Instantiate(targetTemp);
                newTarget.name = targetTemp.name;
            }
        }
    }
}
