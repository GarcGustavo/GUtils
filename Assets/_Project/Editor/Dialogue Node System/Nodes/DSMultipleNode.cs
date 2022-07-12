using _Project.DialogueSystem.Enumerations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Editor.Dialogue_Node_System.Nodes
{
	public class DSMultipleNode : DSNode
	{
		public override void Initialize(Vector2 position)
		{
			base.Initialize(position);

			DialogueType = DSDialogueType.Multiple;
			DialogueChoices.Add("New node");
		}

		public override void Draw()
		{
			base.Draw();
			
			Button add_button = new Button()
			{
				text = "Add choice"
			};
			
			mainContainer.Insert(1, add_button);
			
			// Instantiate choice output nodes
			foreach (var choice in DialogueChoices)
			{ 
				Port choice_port = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
				choice_port.name = "";
				
				Button delete_button = new Button()
				{
					text = "X"
				};
				
				TextField choice_text = new TextField()
				{
					value = choice
				};
				
				choice_port.Add(choice_text);
				choice_port.Add(delete_button);
				outputContainer.Add(choice_port);
			}
			
			RefreshExpandedState();
		}
	}
}