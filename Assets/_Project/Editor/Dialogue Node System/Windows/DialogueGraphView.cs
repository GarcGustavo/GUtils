using System;
using _Project.DialogueSystem.Enumerations;
using _Project.Editor.Dialogue_Node_System.Nodes;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Editor.Dialogue_Node_System.Windows
{
	public class DialogueGraphView : GraphView
	{
		public DialogueGraphView()
		{
			AddManipulators();
			//GenerateEntryPointNode();
			AddBackground();
			//CreateNode();
			AddStyles();
		}

		private DSNode CreateNode(DSDialogueType new_node_type, Vector2 position)
		{
			DSNode node = new DSNode();
			Type node_type = Type.GetType($"_Project.Editor.Dialogue_Node_System.Nodes.DS{new_node_type}Node");
			node = (DSNode) Activator.CreateInstance(node_type);
			
			node.Initialize(position);
			node.Draw();
			return node;
		}

		private void AddManipulators()
		{
			SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
			this.AddManipulator(new ContentDragger());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());
			this.AddManipulator(CreateNodeContextMenu("Add Node (Single Choice) ", DSDialogueType.Single));
			this.AddManipulator(CreateNodeContextMenu("Add Node (Multiple Choice) ", DSDialogueType.Multiple));
			this.AddManipulator(CreateNodeContextMenu("Add Node (Contextual) ", DSDialogueType.Contextual));
			//this.AddManipulator(new EdgeManipulator());
			//this.AddManipulator(new FreehandSelector());
		}

		private IManipulator CreateNodeContextMenu(string node_text, DSDialogueType new_node_type)
		{
			// Adding actions to context menu w/ callbacks
			ContextualMenuManipulator context_menu = new ContextualMenuManipulator(
				menu_event => menu_event.menu
					.AppendAction(node_text, action_event => 
						AddElement(CreateNode(new_node_type, action_event.eventInfo.localMousePosition)))
				);
			
			return context_menu;
		}

		private void GenerateEntryPointNode()
		{
			var node = new DSNode();
			AddElement(node);
		}

		private void AddBackground()
		{
			GridBackground grid_background = new GridBackground();
			grid_background.StretchToParentSize();
			Insert(0, grid_background);
		}

		private void AddStyles()
		{
			StyleSheet style_sheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/GraphViewStyle.uss");
			styleSheets.Add(style_sheet);
		}
		
	}
}