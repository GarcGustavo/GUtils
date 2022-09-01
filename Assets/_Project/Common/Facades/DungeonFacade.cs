using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using DungeonArchitect;
// using DungeonArchitect.Builders.Grid;
// using DungeonArchitect.Builders.GridFlow;
// using DungeonArchitect.Builders.Maze;
// using DungeonArchitect.MiniMaps;

namespace Scriptable_Objects
{
	[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Create Dungeon", order = 0)]
	public class DungeonFacade : ScriptableObject
	{
		public List<GameObject> DungeonCellData()
		{
			throw new System.NotImplementedException();
		}

		public void DestroyDungeon()
		{
			throw new System.NotImplementedException();
		}

		public void RandomizeSeed()
		{
			throw new System.NotImplementedException();
		}

		public void RequestRebuild()
		{
			throw new System.NotImplementedException();
		}

		public void Build()
		{
			throw new System.NotImplementedException();
		}

		public DungeonConfig GetConfig()
		{
			throw new System.NotImplementedException();
		}
	}

	public class DungeonConfig
	{
	}
}