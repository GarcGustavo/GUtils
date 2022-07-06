using UnityEngine;

//<summary>
// TestMono full description
//</summary>

public class TestMono : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tooltip example")]
    private int _exampleInt;
    void Awake()
    {
        // TestMono code to run on initialization
    }
    
    void Start()
    {
        // TestMono code to run at start of scene
    }
    
    void Update()
    {
        // TestMono code to run each frame
    }
    
    
}