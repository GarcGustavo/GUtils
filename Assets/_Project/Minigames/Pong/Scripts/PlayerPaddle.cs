using System;
using UnityEngine;

namespace _Project.Minigames.Pong.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPaddle : MonoBehaviour, IPaddle
    {
        private Rigidbody2D _rigidbody;
        [SerializeField] private string _playerName;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Vector2 _startPosition = new Vector2();

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction;
        }

        public void Reset()
        {
            transform.position = _startPosition;
        }

        private void FixedUpdate()
        {
            Move(Input.GetAxis("Vertical") != 0 ? new Vector2(0, Input.GetAxis("Vertical") * _speed) : Vector2.zero);
        }

        // private void OnCollisionEnter2D(Collision2D collision)
        // {
        //     Debug.Log("Hit Paddle");
        //     var contact_point = collision.contacts[0];
        //     var direction = Vector2.Reflect(transform.position,
        //         collision.transform.position);
        //     _rigidbody.AddForce(direction * _rigidbody.velocity, ForceMode2D.Impulse);
        // }
    }
}
