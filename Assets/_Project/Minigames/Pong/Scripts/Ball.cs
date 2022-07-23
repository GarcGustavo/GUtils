using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Minigames.Pong.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        // Set tags for different surface types to change ball behaviour
        [SerializeField] private string collisionTag = "";
        [SerializeField] private string goalTag = "";
        
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Vector3 _direction = new Vector3(0, 0, 0);
        [SerializeField] private Vector2 _startPosition = new Vector2();
        [SerializeField] private ParticleSystem _explosionParticlesPrefab;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
        }

        public void InitializeMovement(Vector2 direction)
        {
            _direction = direction;
            _rigidbody.AddForce(_direction * _speed, ForceMode2D.Impulse);
        }

        public void ResetPosition()
        {
            Instantiate(_explosionParticlesPrefab, transform.position, Quaternion.identity);
            _direction = new Vector2(1, 0);
            _rigidbody.velocity = Vector2.zero;
            transform.position = _startPosition;
        }
        
        void OnCollisionEnter2D(Collision2D col) {
            // Note: 'col' holds the collision information. If the
            // Ball collided with a racket, then:
            //   col.gameObject is the racket
            //   col.transform.position is the racket's position
            //   col.collider is the racket's collider

            // Hit the left Racket?
            if (col.gameObject.name == "LeftPaddle") {
                // Calculate hit Factor
                Debug.Log("Hit Paddle");
                float y = hitFactor(transform.position,
                    col.transform.position,
                    col.collider.bounds.size.y);

                // Calculate direction, make length=1 via .normalized
                Vector2 dir = new Vector2(-transform.position.x, y * 4).normalized;

                // Set Velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir * _speed;
            }

            // Hit the right Racket?
            if (col.gameObject.name == "RightPaddle") {
                // Calculate hit Factor
                float y = hitFactor(transform.position,
                    col.transform.position,
                    col.collider.bounds.size.y);

                // Calculate direction, make length=1 via .normalized
                Vector2 dir = new Vector2(-transform.position.x, y).normalized;

                // Set Velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir * _speed;
            }
        }
        
        float hitFactor(Vector2 ballPos, Vector2 racketPos,
            float racketHeight) {
            // ascii art:
            // ||  1 <- at the top of the racket
            // ||
            // ||  0 <- at the middle of the racket
            // ||
            // || -1 <- at the bottom of the racket
            return (ballPos.y - racketPos.y) / racketHeight;
        }
        
    }
}
