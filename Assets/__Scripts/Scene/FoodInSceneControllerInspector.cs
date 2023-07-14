
#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(FoodInSceneController))]
public class FoodInSceneControllerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        FoodInSceneController spawner = (FoodInSceneController)target;

        if (GUILayout.Button("Spawn"))
        {
            spawner.SpawnFood();
        }
    }
}

#endif
