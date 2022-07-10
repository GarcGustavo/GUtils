using _Project.Editor.Dialogue_Node_System.Nodes;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Editor.Dialogue_Node_System
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

		private DSNode CreateNode(Vector2 position)
		{
			DSNode node = new DSNode();
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
			this.AddManipulator(CreateNodeContextMenu());
			//this.AddManipulator(new EdgeManipulator());
			//this.AddManipulator(new FreehandSelector());
		}

		private IManipulator CreateNodeContextMenu()
		{
			// Adding actions to context menu w/ callbacks
			ContextualMenuManipulator context_menu = new ContextualMenuManipulator(
				menu_event => menu_event.menu
					.AppendAction("Add Node", action_event => 
						AddElement(CreateNode(action_event.eventInfo.localMousePosition)))
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