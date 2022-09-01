using System.Collections;
using System.Collections.Generic;
//using Cysharp.Threading.Tasks;

namespace CombatSystem.Commands
{
	public interface ICommand
	{
		IEnumerator Execute();
		float duration { get; set; }
	}
}