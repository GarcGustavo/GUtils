using System.Collections;
using UnityEngine;
using static _Project.Common.CommonUtils;

namespace CombatSystem.Commands
{
	public class AttackCommand : ICommand
	{
		private CombatUnit _combatUnit;

		public AttackCommand(CombatUnit combat_unit)
		{
			_combatUnit = combat_unit;
		}
		public IEnumerator Execute()
		{
			//possibly replace with generic logic and simply pass character/attack data into each concrete command
			_combatUnit.ExecuteAttack();
			yield return GetWaitForSeconds(duration);
		}

		public float duration { get; set; }
	}
}