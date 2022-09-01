using System;
using System.Collections.Generic;
using _Project.Systems.UI;
using TMPro;
using UnityEngine;

namespace _Project.Common.UI
{
	public class ActionMenu : MonoBehaviour
	{
		private Systems.UI.UIManager _uiManager;
		[SerializeField] private InputManager inputManager;
		[SerializeField] private Transform textParent;
		[SerializeField] private TMP_Text TmpPrefab;
		private List<TMP_Text> actionsTMP;
		[SerializeField] private String[] actionNames = new []{"Attack", "Talk", "Item", "Run"};
		private int _previousIdx = 0;
		private int _currentIdx = 0;
		private float _fontSize = 0;
		private Vector2 _playerInput;
		
		private void Awake()
		{
			var placement_counter = 0;
			actionsTMP = new List<TMP_Text>();
			_fontSize = TmpPrefab.fontSize;
			foreach (var action in actionNames)
			{
				var command = Instantiate(TmpPrefab, textParent);
				var size_delta = command.rectTransform.sizeDelta;
				command.text = action;
				command.rectTransform.anchoredPosition = new Vector2(0, command.rectTransform.anchoredPosition.y + -placement_counter * size_delta.y * .75f);
				placement_counter  += 1;
				actionsTMP.Add(command);
			}
			HighlightAction();
		}

		private void Update()
		{
			if (Input.anyKeyDown)
				NextAction(inputManager.GetMovementInput().y);
		}
		
		private void NextAction(float input)
		{
			switch (input)
			{
				case < 0:
					_previousIdx = _currentIdx;
					_currentIdx = (_currentIdx == actionNames.Length - 1) ? 0: _currentIdx + 1;
					HighlightAction();
					break;
				case > 0:
					_previousIdx = _currentIdx;
					_currentIdx = (_currentIdx == 0) ? actionNames.Length - 1: _currentIdx - 1;
					HighlightAction();
					break;
				default:
					break;
			}
		}
		
		private void HighlightAction()
		{
			actionsTMP[_previousIdx].fontSize = _fontSize;
			actionsTMP[_previousIdx].text = actionNames[_previousIdx];
			actionsTMP[_previousIdx].color = Color.white;
			
			actionsTMP[_currentIdx].text = "> " + actionNames[_currentIdx];
			actionsTMP[_currentIdx].fontSize = _fontSize * 1.5f;
			actionsTMP[_currentIdx].color = Color.green;
			actionsTMP[_currentIdx].outlineColor = Color.white;
			//GTween.StopTween(actionsTMP[_previousIdx].rectTransform);
			//GTween.BounceObject(actionsTMP[_currentIdx].rectTransform, .5f, 1, LoopType.Yoyo, true);
			//GTween.MoveObject(actionsTMP[_previousIdx].rectTransform, actionsTMP[_currentIdx].rectTransform.anchoredPosition, .5f);
			//GTween.MoveObject(actionsTMP[_currentIdx].rectTransform, textParent.position, .5f);
			//GTween.SwapPositions(actionsTMP[_currentIdx].rectTransform, actionsTMP[_previousIdx].rectTransform, .25f, Ease.OutCirc);
			
		}

		private void SelectAction(PlayerAction action)
		{
			action.Execute();
		}
	}
}