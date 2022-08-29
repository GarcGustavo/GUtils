using UnityEngine;

namespace _Project.Systems.UI
{
	[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Player Action", order = 0)]
	public class PlayerAction : ScriptableObject
	{
		private UIManager _uiManager;
		public string actionName;
		public int damage;
		
		public void Execute()
		{
		}
		
	}
}