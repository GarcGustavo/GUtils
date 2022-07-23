using _Project.ScriptableDialogue.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.ScriptableDialogue.Objects
{
	public enum Mood {
		Neutral,
		Angry
	}

	[System.Serializable]
	public struct Line
	{
		public DialogueCharacter character;

		[TextArea(2, 5)]
		public string text;
		public Mood mood;
	}

	[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
	public class Conversation : ScriptableObject
	{
		public DialogueCharacter speakerLeft;
		public DialogueCharacter speakerRight;
		public Line[] lines;
		public Question question;
		public Conversation nextConversation;
	}
}