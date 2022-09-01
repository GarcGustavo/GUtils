using System;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

namespace _Project.Common
{
	[CreateAssetMenu(fileName = "NewInputManager", menuName = "ScriptableObjects/Managers/InputManager", order = 0)]
	public class InputManager : ScriptableObject
	{
		public KeyCode UpKey { get; set; }
		public KeyCode LeftKey { get; set; }
		public KeyCode DownKey { get; set; }
		public KeyCode RightKey { get; set; }
		public KeyCode JumpKey { get; set; }
		public KeyCode ActionKey { get; set; }
		
		private Vector2 _inputVector = Vector2.zero;

		public void UpdateInputKeys()
		{
			UpKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
			LeftKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
			DownKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
			RightKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
			JumpKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
			ActionKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actionKey", "E"));
		}

		public void GetPlayerInput()
		{
			if (Input.GetKeyDown(ActionKey))
			{
				GEvents.playerAction();
			}
		}

		public Vector2 GetMovementInput()
		{
			_inputVector.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			return _inputVector;
		}
		
		public Vector2 GetMousePosition()
		{
			var mousePos = Input.mousePosition;
			return new Vector2(mousePos.x, mousePos.y);
		}

	}
}