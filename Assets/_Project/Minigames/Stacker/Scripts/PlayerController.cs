using _Project.Common;
using UnityEngine;

//<summary>
// PlayerController full description
//</summary>
namespace _Project.Minigames.Stacker.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10.0f;
        [SerializeField] private bool _canMove;
        [SerializeField] private InputManager _inputManager;
        private CharacterController _characterController;
        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _canMove = true;
        }
        
        void FixedUpdate()
        {
            if (_canMove)
                _characterController.Move(_inputManager.GetMovementInput() * _speed * Time.deltaTime);
        }
        
        public void SetMovement(bool canMove)
        {
            _canMove = canMove;
        }
        
    }
}