using UnityEngine;

namespace _Project.Systems.UI.Conversation
{
	[CreateAssetMenu(fileName = "GDialogue", menuName = "Dialogue Data", order = 0)]
	public class DialogueData : ScriptableObject
	{
		public string[] DialogueName;
		public string[] DialogueText;
		public Sprite[] DialoguePortrait;
		public AudioClip[] DialogueAudio;
		public bool[] DialogueAudioLoop;
	}
}