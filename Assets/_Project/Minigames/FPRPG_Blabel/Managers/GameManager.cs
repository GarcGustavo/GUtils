using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Base_Classes;
using Base_Classes.Components;
using Managers;
//using Flockaroo;
using PlayerComponents;
using Scriptable_Objects;
using States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Random = System.Random;
using State = Base_Classes.State;

public class GameManager : MonoBehaviour
{
    //Game State
    //private State state;
    public enum TurnState
    {
        Player,
        Enemy,
        Interacting
    }

    public TurnState activeTurn;
    public int turnCounter;
    //[SerializeField] private int maxHeight = 25;
    //[SerializeField] private int maxWidth = 25;
    //[SerializeField] private bool uiEnabled;
    
    //Player State
    [SerializeField] private Player player;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private bool playerSpawned = false;
    
    //Level generation
    [SerializeField] private Grid grid;
    [FormerlySerializedAs("dungeon")] [SerializeField] private DungeonFacade dungeonFacade;
    //[SerializeField] private MazeDungeonConfig dungeonConfig;
    [SerializeField] private DungeonConfig dungeonConfig;
    [SerializeField] private UIManager uiManager;
    //private bool rebuilding = false;
    public bool dungeonBuilt = false;
    //public int dungeonSizeX;
    //public int dungeonSizeY;

    //Level Data
    [SerializeField] private List<GridCell> gridCells;
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private Exit exit;
    
    //Movement grid directions
    public enum Direction { North = 0, East = 1, South = 2, West = 3};
    private PlayerGridMovement _movementGrid;
    
    // -------------------------Singleton Setup-------------------------
    private static GameManager _instance;
    [SerializeField] private EventsManager _events;
    public float _turnCD = .2f;
    private bool _unitMoving = false;

    public static GameManager GetInstance()
    {
        return _instance;
    }
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

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        ManageTurns();
    }

    private void ManageTurns()
    {
        if (!playerSpawned) return;
        switch (activeTurn)
        {
            case TurnState.Player:
                if (!(player.ActionPoints > 0 && !_unitMoving)) break;
                _movementGrid.GetMovementInput();
                break;
            case TurnState.Enemy:
                if (_unitMoving) break;
                foreach (var enemy in enemies)
                {
                    enemy.EnemyAction();
                    enemy._unitGrid.finishedMoving = true;
                }
                _events.enemyTurn.Invoke();
                UpdateTurn();
                break;
        }
    }
    private IEnumerator TurnDelay()
    {
        _unitMoving = true;
        yield return new WaitForSeconds(_turnCD);
        _unitMoving = false;
    }

    // -------------------------Initializers-------------------------

    void StartGame()
    {
        _events = EventsManager.GetInstance();
        _events.endRound.AddListener(ReloadLevel);
        activeTurn = TurnState.Player;
        playerSpawned = false;
        StartCoroutine(nameof(InitializeLevel));
        SetState(new Exploring(this));
    }
    IEnumerator InitializeLevel() {
  
        dungeonFacade.RandomizeSeed();
        dungeonFacade.Build();
        
        yield return new WaitUntil(() => dungeonBuilt);

        turnCounter = 0;
        dungeonBuilt = false;
        grid = GetComponentInChildren<Grid>();
        dungeonConfig = transform.GetComponentInChildren<DungeonConfig>();
        enemies = new List<Enemy>();
        GenerateNewMap();
        _events.initializeMovementGrid.Invoke();
        _events.newTurn.Invoke();
    }
    private void ReloadLevel()
    {
        StartCoroutine("Rebuild");
    }

    private IEnumerator Rebuild() 
    {
        playerSpawned = false;
        dungeonFacade.RandomizeSeed();
        dungeonFacade.RequestRebuild();
        
        yield return new WaitUntil(() => dungeonBuilt);

        turnCounter = 0;
        dungeonBuilt = false;
        grid = GetComponentInChildren<Grid>();
        dungeonConfig = transform.GetComponentInChildren<DungeonFacade>().GetConfig();
        enemies = new List<Enemy>();
        GenerateNewMap();
        _events.initializeMovementGrid.Invoke();
        _events.newTurn.Invoke();
        uiManager.ReloadUI();
        
    }
    // -------------------------Dungeon Methods-------------------------
    private void GenerateNewMap()
    {
        gridCells.Clear();
        var cellData = dungeonFacade.DungeonCellData();
        
        foreach (var item in cellData)
        {
            if (!item.GetComponent<GridCell>()) continue;
            var nextGridCell = item.GetComponent<GridCell>();
            nextGridCell.gridPosition = grid.WorldToCell(nextGridCell.transform.position);
            nextGridCell.occupant = null;
            nextGridCell.blocked = false;
            gridCells.Add(nextGridCell);
        }

        foreach (var item in cellData)
        {
            var itemTag = item.tag;
            switch (itemTag)
            {
                case "Player":
                    player = item.GetComponent<Player>();
                    var playerCell = GetDungeonCell(grid.WorldToCell(player.transform.position));
                    player.InitializeUnit(playerCell);
                    _movementGrid = player.GetComponent<PlayerGridMovement>();
                    playerSpawned = true;
                    break;
                case "Enemy":
                    var enemy = item.GetComponent<Enemy>();
                    var enemyCell = GetDungeonCell(grid.WorldToCell(enemy.transform.position));
                    enemy.InitializeUnit(enemyCell);
                    enemies.Add(enemy);
                    break;
                case "Wall":
                    var wall = item.GetComponent<Wall>();
                    var wallCell = GetDungeonCell(grid.WorldToCell(wall.transform.position));
                    wall.InitializeUnit(wallCell);
                    break;
                case "Door":
                    var door = item.GetComponent<Door>();
                    var doorCell = GetDungeonCell(grid.WorldToCell(door.transform.position));
                    door.InitializeUnit(doorCell);
                    break;
                case "Item":
                    var itemDrop = item.GetComponent<Item>();
                    var itemCell = GetDungeonCell(grid.WorldToCell(itemDrop.transform.position));
                    itemDrop.InitializeUnit(itemCell);
                    break;
                case "Key":
                    var key = item.GetComponent<Key>();
                    var keyCell = GetDungeonCell(grid.WorldToCell(key.transform.position));
                    key.InitializeUnit(keyCell);
                    break;
                case "Weapon":
                    var weaponDrop = item.GetComponent<Weapon>();
                    var weaponCell = GetDungeonCell(grid.WorldToCell(weaponDrop.transform.position));
                    weaponDrop.InitializeUnit(weaponCell);
                    break;
                case "Exit":
                    exit = item.GetComponent<Exit>();
                    var exitCell = GetDungeonCell(grid.WorldToCell(exit.transform.position));
                    exit.InitializeUnit(exitCell);
                    break;
            }
        }
    }
    
    public GridCell GetDungeonCell(Vector3Int targetPos)
    {
        foreach (var cell in gridCells)
        {
            //Position received needs to swap Z and Y values so that Z=0
            var target = targetPos;
            if (target.x == cell.gridPosition.x && target.y == cell.gridPosition.y)
            {
                return cell;
            }
        }
        return null;
    }
    public List<GridCell> GetNeighborGridCells(Vector3Int grid_cell)
    {
        var grid_cell_list = new List<GridCell>();
        var neighbor_cells = new List<Vector3Int>
        {
            grid_cell + Vector3Int.up,
            grid_cell + Vector3Int.right,
            grid_cell + Vector3Int.down,
            grid_cell + Vector3Int.left
        };
        foreach (var cell in neighbor_cells)
        {
            var next_cell = GetDungeonCell(cell);
            if(next_cell != null) grid_cell_list.Add(next_cell);
        }
        return grid_cell_list;
    }
    public List<Vector3Int> GetNeighborCells(Vector3Int grid_cell)
    {
        var neighbor_cells = new List<Vector3Int>
        {
            grid_cell + Vector3Int.up,
            grid_cell + Vector3Int.right,
            grid_cell + Vector3Int.down,
            grid_cell + Vector3Int.left
        };
        return neighbor_cells;
    }

    // -------------------------State Methods-------------------------
    public void UpdateTurn()
    {
        switch (activeTurn)
        {
            case TurnState.Player:
            {
                player.ActionPoints -= 1;
                if (player.ActionPoints <= 0)
                {
                    uiManager.LogAction.Invoke("Enemy turn");
                    activeTurn = TurnState.Enemy;
                    turnCounter++;
                }
                //StartCoroutine(TurnDelay());
                _events.newTurn.Invoke();
                break;
            }

            case TurnState.Enemy:
            {
                player.ActionPoints = player._agility;
                //Debug.Log("Player turn");
                //uiManager.LogAction.Invoke("Player turn");
                activeTurn = TurnState.Player;
                //StartCoroutine(TurnDelay());
                _events.newTurn.Invoke();
                break;
            }
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public void EndRound()
    {
        _events.endRound.Invoke();
    }
    
    public List<GridCell> GetGridCells()
    {
        return gridCells;
    }

    public void SetState(State newState)
    {
        //state = newState;
        //StartCoroutine(state.Enter());
    }

    //public State GetState()
    //{
        //return state;
    //}
    public Player GetPlayer()
    {
        return player;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    public int GetTurn()
    {
        return turnCounter;
    }
    public DungeonFacade GetDungeon()
    {
        return dungeonFacade;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    public Camera GetCamera()
    {
        return playerCamera;
    }

}
