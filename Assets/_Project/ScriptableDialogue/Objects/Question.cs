using UnityEngine;
using UnityEngine.UI;

namespace _Project.ScriptableDialogue.Objects
{

	[System.Serializable]
	public struct Choice
	{
		[TextArea(2, 5)]
		public string text;
		public Conversation conversation;
	}
	
	[CreateAssetMenu(fileName = "New Question", menuName = "Question", order = 0)]
	public class Question : ScriptableObject
	{
		[TextArea(2, 5)]
		public string text;
		public Choice[] choices;
	}
}