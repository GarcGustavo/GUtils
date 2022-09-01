using Base_Classes;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Events", order = 0)]
	public class EventData : ScriptableObject
	{
		//General
		public UnityEvent initializeMovementGrid;
		public UnityEvent endRound;
		public UnityEvent newTurn;
		public UnityEvent<int> unlockDoor;
		//Player
		public UnityEvent<float> playerDamage;
		public UnityEvent<GridCell> pickUpItem;
		public UnityEvent playerHeal;
		public UnityEvent playerDeath;
		//Enemy
		public UnityEvent enemyTurn;
		public UnityEvent<Vector3Int> enemyAttack;
		public UnityEvent<Vector3Int, float> unitDamage;
		public UnityEvent<Vector3Int, float> unitHeal;
	}
}