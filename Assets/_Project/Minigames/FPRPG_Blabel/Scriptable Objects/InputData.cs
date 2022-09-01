using UnityEngine;

namespace Scriptable_Objects
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Inputs", order = 0)]
	public class InputData : ScriptableObject
	{
        public void GetInput()
        {
            if (Input.GetButton("Up"))
            {
            }
            else if (Input.GetButtonDown("Down"))
            {
            }
            else if (Input.GetButtonDown("Left"))
            {
            }
            else if (Input.GetButtonDown("Right"))
            {
            }
            else if (Input.GetButton("Fire1"))
            {
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                
            }
        }
	}
}