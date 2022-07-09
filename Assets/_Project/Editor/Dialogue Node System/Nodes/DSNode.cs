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
		public List<string> DialogueOptions{ get; set; }
		public string Text{ get; set; }
		public DSDialogueType DialogueType { get; set; }
		
		public void	Initialize()
		{
			DialogueName = "DialogueName";
			DialogueOptions = new List<string>();
			Text = "text";
			DialogueType = DSDialogueType.SingleChoice;
		}

		public void Draw()
		{
			
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