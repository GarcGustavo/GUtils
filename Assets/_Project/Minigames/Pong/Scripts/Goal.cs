using System;
using UnityEngine;

namespace _Project.Minigames.Pong.Scripts
{
    public class Goal : MonoBehaviour
    {
        [SerializeField] private bool _playerGoal;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Hit Goal");
            if (other.CompareTag("PongBall"))
            {
                PongManager.Instance.Goal(_playerGoal);
            }
        }
    }
}
