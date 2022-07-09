using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//<summary>
// StackerManager full description
//</summary>

namespace _Project.Minigames.Stacker.Scripts
{
    public class StackerManager : MonoBehaviour
    {
        private static StackerManager _instance;
        public static StackerManager Instance{ get { return _instance; } }
        
        [SerializeField] private float _spawnCD = .5f;
        [SerializeField] private int _maxBlockCount = 10;
        [SerializeField] private float _blockSpawnArea = 7f;
        [SerializeField] private Score _score;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private List<GameObject> _blockPrefabs;
        private List<GameObject> _blockPool;
        private bool _roundActive;
        private Camera _camera;
        [SerializeField] private Plate _plate;
        [SerializeField] private Transform _plateParent;
        public Plate PlateObject{ get{ return _plate; } }
        public Transform PlateParent{ get{ return _plateParent; } }

        void Awake()
        {
            //Singleton creation
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
            _camera = Camera.main;
            _blockPool = new List<GameObject>();
            
        }
    
        void Start()
        {
            StartRound();
        }

        void Update()
        {
            // StackerManager code to run each frame
        }

        private List<GameObject> CreateObjectPool(List<GameObject> block_prefabs, int max_blocks)
        {
            var new_pool = new List<GameObject>();
            foreach (var block_prefab in block_prefabs)
            {
                for (int i = 0; i < max_blocks; i++)
                {
                    var block = Instantiate(block_prefab);
                    block.SetActive(false);
                    new_pool.Add(block);
                }
            }
            return new_pool;
        }

        public void StartRound()
        {
            _blockPool = CreateObjectPool(_blockPrefabs, _maxBlockCount);
            _roundActive = true;
            StartCoroutine(StartSpawner());
        }
    
        public void StopRound()
        {
            _roundActive = false;
            StopCoroutine(StartSpawner());
        }

        private void SpawnBlock()
        {
            var block = _blockPool.FirstOrDefault(x => !x.activeSelf);
            if (block == null) return;
            var random_position = _spawnPoint.position.x + Random.Range(-_blockSpawnArea, _blockSpawnArea);
            block.SetActive(true);
            block.transform.position = new Vector3(random_position, _spawnPoint.position.y, -1);
            block.transform.rotation = Quaternion.identity;
        }
    
        IEnumerator StartSpawner()
        {
            while (_roundActive)
            {
                yield return new WaitForFixedUpdate();
                SpawnBlock();
                yield return new WaitForSeconds(_spawnCD);
            }
        }
    
    }
}