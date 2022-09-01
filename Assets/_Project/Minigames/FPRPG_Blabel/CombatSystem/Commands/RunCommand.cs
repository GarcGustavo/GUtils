using System.Collections;
using System.Collections.Generic;
using static _Project.Common.CommonUtils;

namespace CombatSystem.Commands
{
	public class RunCommand : ICommand
	{
		private CombatUnit _combatUnit;
		public IEnumerator Execute()
		{
			//possibly replace with generic logic and simply pass character/attack data into each concrete command
			_combatUnit.ExecuteAttack();
			yield return GetWaitForSeconds(duration);
		}

		public float duration { get; set; }
	}
}