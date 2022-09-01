using System;
using UnityEngine;

namespace _Project.Common
{
	[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "GEvents", order = 0)]
	public class GEvents : ScriptableObject
	{
		//General
		public static Action startRound;
		public static Action endRound;
		//Player
		public static Action playerAction;
		public static Action playerTurnStart;
		public static Action playerTurnEnd;
		public static Action playerSpawn;
		public static Action playerDeath;
		//Enemy
		public static Action enemyTurnStart;
		public static Action enemyTurnEnd;
		public static Action enemyDeath;
		
		public static void StartRound()
		{
			startRound?.Invoke();
		}
		
		public static void EndRound()
		{
			endRound?.Invoke();
		}
		
		public static void PlayerAction()
		{
			playerAction?.Invoke();
		}
		
		public static void PlayerTurnStart()
		{
			playerTurnStart?.Invoke();
		}
		
		public static void PlayerTurnEnd()
		{
			playerTurnEnd?.Invoke();
		}
		
		public static void PlayerSpawn()
		{
			playerSpawn?.Invoke();
		}
		
		public static void PlayerDeath()
		{
			playerDeath?.Invoke();
		}
		
		public static void EnemyTurnStart()
		{
			enemyTurnStart?.Invoke();
		}
		
		public static void EnemyTurnEnd()
		{
			enemyTurnEnd?.Invoke();
		}
		
		public static void EnemyDeath()
		{
			enemyDeath?.Invoke();
		}
		
		public static void Clear()
		{
			startRound = null;
			endRound = null;
			playerAction = null;
			playerTurnStart = null;
			playerTurnEnd = null;
			playerSpawn = null;
			playerDeath = null;
			enemyTurnStart = null;
			enemyTurnEnd = null;
			enemyDeath = null;
		}

	}
}