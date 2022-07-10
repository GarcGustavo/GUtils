using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Editor.Dialogue_Node_System
{
	public class DialogueGraph : EditorWindow
	{
		private DialogueGraphView _graphView;
		//private DialogueGraphView _graphView;
		
		[MenuItem("Graph/Dialogue Graph")]
		public static void OpenDialogueGraphWindow()
		{
			var window = GetWindow<DialogueGraph>();
			window.titleContent = new GUIContent("Dialogue Graph");
		}

		private void OnEnable()
		{ 
			AddGraph();
			AddStyles();
		}

		private void OnDisable()
		{
			rootVisualElement.Remove(_graphView);
		}

		private void AddGraph()
		{
			_graphView = new DialogueGraphView();
			rootVisualElement.Add(_graphView);
			_graphView.StretchToParentSize();
		}

		private void AddStyles()
		{
			StyleSheet style_sheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DSVariables.uss");
			rootVisualElement.styleSheets.Add(style_sheet);
		}
	}
}