using UnityEngine;

namespace _Project.Minigames.Pong.Scripts
{
    public interface IPaddle
    {
        // Receive AI input vector
        void Move(Vector3 direction);
        
        // Return paddle to start position
        void Reset();
    }
}
