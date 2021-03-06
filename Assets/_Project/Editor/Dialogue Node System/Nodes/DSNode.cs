using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using _Project.DialogueSystem.Enumerations;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Editor.Dialogue_Node_System.Nodes
{
	public class DSNode : Node
	{
		public string DialogueName{ get; set; }
		public List<string> DialogueChoices{ get; set; }
		public string Text{ get; set; }
		public DSDialogueType DialogueType { get; set; }
		
		public virtual void	Initialize(Vector2 position)
		{
			DialogueName = "Node name";
			//Text = "Dialogue text";
			DialogueChoices = new List<string>();
			//DialogueType = DSDialogueType.SingleChoice;
			SetPosition(new Rect(position, Vector2.zero));
		}

		public virtual void Draw()
		{
			// Title
			TextField dialogue_name_field = new TextField(){ value = DialogueName };
			dialogue_name_field.AddToClassList("ds-node__text-field");
			dialogue_name_field.AddToClassList("ds-node__text-field__hidden");
			dialogue_name_field.AddToClassList("ds-node__filename-text-field");
			titleContainer.Insert(0, dialogue_name_field);
			
			// Input/Output Nodes
			Port input_port = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
			//Port output_node = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
			input_port.portName = "Input Node";
			//output_node.portName = "Output Node";
			inputContainer.Add(input_port);
			//inputContainer.Add(output_node);

			// Temp. container
			VisualElement data_container = new VisualElement();
			
			// Input Field
			Foldout text_foldout = new Foldout(){ text = "Text" };
			TextField text_field = new TextField(Text){ value = Text };
			
			text_field.AddToClassList("ds-node__text-field");
			text_field.AddToClassList("ds-node__quote-text-field");
			
			// Populating node fields
			text_foldout.Add(text_field);
			data_container.Add(text_foldout);
			extensionContainer.Add(data_container);
			RefreshExpandedState();
		}

		public void DisconnectAllPorts()
		{
			
		}
		
		private void DisconnectInputPorts()
		{
			
		}
		
		private void DisconnectOutputPorts()
		{
			
		}
		
		private void DisconnectPorts(VisualElement container)
		{
			
		}
		
		public bool IsStartingNode()
		{
			return false;
		}
		
		public void SetErrorStyle(Color color)
		{
			
		}
		
		public void ResetStyle()
		{
			
		}
		
	}
}