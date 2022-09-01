using System;
using UnityEngine;
using static System.Action;
using static _Project.Common.GEvents;

namespace _Project.Systems.UI
{
	[CreateAssetMenu(fileName = "Managers", menuName = "UIManager", order = 0)]
	public class UIManager : ScriptableObject
	{
		//public events
		private static readonly Action _updateUIEvent = delegate { };
		private static readonly Action _selectEvent = delegate { };

		public static void InvokeUpdate()
		{
			_updateUIEvent?.Invoke();
		}

		public static void InvokeSelect()
		{
			_selectEvent?.Invoke();
		}
		
	}
}