using _Project.DialogueSystem.Enumerations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace _Project.Editor.Dialogue_Node_System.Nodes
{
	public class DSSingleNode : DSNode
	{
		public override void Initialize(Vector2 position)
		{
			base.Initialize(position);

			DialogueType = DSDialogueType.Single;
			DialogueChoices.Add("Next dialogue node");
		}

		public override void Draw()
		{
			base.Draw();
			// Instantiate choice output nodes
			foreach (var choice in DialogueChoices)
			{ 
				Port choice_port = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
				choice_port.name = choice;
				outputContainer.Add(choice_port);
			}
			
			RefreshExpandedState();
		}
	}
}