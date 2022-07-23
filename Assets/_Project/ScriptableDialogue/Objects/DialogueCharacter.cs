using UnityEngine;

namespace _Project.ScriptableDialogue.Objects
{
	[CreateAssetMenu(fileName = "New Dialogue Character", menuName = "Dialogue Character", order = 0)]
	public class DialogueCharacter : ScriptableObject
	{
		public string fullName;
		public Sprite portrait;
		public Sprite portraitAngry;
	}
}