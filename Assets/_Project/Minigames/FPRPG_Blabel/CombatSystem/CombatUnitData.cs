using System.Collections.Generic;
using System.Threading.Tasks;
using CombatSystem.Commands;
//using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CombatSystem
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CombatUnitData", order = 0)]
	public class CombatUnitData : ScriptableObject
	{
		private CombatUnitData _unit;
		public int hp = 100;
		public int mp = 100;
		
	}
}