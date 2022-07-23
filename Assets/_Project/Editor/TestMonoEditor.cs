using UnityEditor;
using UnityEngine;

//<summary>
// TestMonoEditor full description
//</summary>

namespace _Project.Editor
{
    [CustomEditor(typeof(TestMono))]
    public class TestMonoEditor : UnityEditor.Editor
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
}