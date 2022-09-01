using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonManager
{
    private GameManager _manager;

    private void Start()
    {
        _manager = GameManager.GetInstance();
    }

    public void OnPostDungeonBuild(DungeonFacade dungeon_facade)
    {
        _manager = GameManager.GetInstance();
        _manager.dungeonBuilt = true;
    }

    public void OnDungeonDestroyed(DungeonFacade dungeon_facade)
    {
        _manager = GameManager.GetInstance();
        _manager.dungeonBuilt = false;
    }

    public void GenerateNewDungeon()
    {
        var dungeon = _manager.GetDungeon();
        dungeon.DestroyDungeon();
        dungeon.RandomizeSeed();
        dungeon.Build();
    }
    
}
