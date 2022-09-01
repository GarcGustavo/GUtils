using System;
using Managers;
using UnityEngine;

namespace Base_Classes
{
	public class Exit : GridUnit
	{
		//private GameManager _localManager;
		private EventsManager _events;

		private void Awake()
		{
			//_localManager = GameManager.GetInstance();
			_events = EventsManager.GetInstance();
		}

		private void LookAtPlayer()
		{
			
		}

		private void LoadNextFloor()
		{
			_events.endRound.Invoke();
		}
		public override void InitializeUnit(GridCell cell)
		{
			_initialCell = cell.gridPosition;
			_currentCell = cell.gridPosition;
			cell.Occupy(this);
			//Debug.Log("Initializing unit " + name);
		}
	}
}