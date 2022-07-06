using UnityEngine;
using UnityEditor;

//<summary>
// TestMonoEditor full description
//</summary>

[CustomEditor(typeof(TestMono))]
public class TestMonoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Example Button"))
        {
            Debug.Log("Test");
        }
        DrawDefaultInspector();
        //script.#VARIABLE# = EditorGUILayout.IntField("#VARIABLE#", script.#VARIABLE#);
    }
}