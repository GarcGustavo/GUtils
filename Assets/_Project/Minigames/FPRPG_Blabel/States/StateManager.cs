using UnityEngine;

namespace Scriptable_Objects
{
	[CreateAssetMenu(fileName = "Data", menuName = "Managers/StateManager", order = 0)]
	public class StateManager : ScriptableObject
	{
		public enum TurnState
		{
			Player,
			Enemy,
			Interacting
		}
	}
}