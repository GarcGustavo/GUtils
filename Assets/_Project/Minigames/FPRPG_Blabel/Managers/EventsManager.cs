using Base_Classes;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
	public class EventsManager : MonoBehaviour
	{
		private static EventsManager _instance;
		void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
				DontDestroyOnLoad(gameObject);
			} 
			else 
			{
				Destroy(this);
			}
		}

		public static EventsManager GetInstance()
		{
			return _instance;
		}
		// -------------------------Events------------------------- //
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