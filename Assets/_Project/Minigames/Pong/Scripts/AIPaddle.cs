using UnityEngine;

namespace _Project.Minigames.Pong.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AIPaddle : MonoBehaviour, IPaddle
    {
        private Rigidbody2D _rigidbody;
        [SerializeField] private string _opponentName;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Vector2 _startPosition = new Vector2();

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
        }
        
        public void Move(Vector3 direction)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                _rigidbody.velocity = new Vector2(0, Input.GetAxis("Vertical") * _speed);
            }
        }

        public void Reset()
        {
            transform.position = _startPosition;
        }

        private void OnCollisionEnter(Collision collision)
        {
        }
        
    }
}
