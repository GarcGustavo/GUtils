using System;
using _Project.Common;
using Scriptable_Objects;
using UnityEngine;
using static Scriptable_Objects.InputData;
using TMPro;

namespace _Project.Systems.UI.Conversation
{
	public class DialogueContainer : MonoBehaviour
	{
		[SerializeField] private DialogueData dialogueData;
		[SerializeField] private InputManager inputManager;
		private TMP_Text _activeName;
		private TMP_Text _activeText;
		private Sprite _activePortrait;
		private string[] _dialogueNames;
		private string[] _dialogueText;
		private Sprite[] _dialoguePortraits;
		private int _dialogueIndex;
		private bool _isDialogueActive;
		private bool _isDialogueFinished;
		private bool _isDialogueSkippable;
		private void Awake()
		{
			_dialogueText = dialogueData.DialogueText;
			_dialogueNames = dialogueData.DialogueName;
			_dialoguePortraits = dialogueData.DialoguePortrait;
			_dialogueIndex = 0;
			_isDialogueActive = false;
			_isDialogueFinished = false;
			_isDialogueSkippable = false;
			GEvents.playerAction += NextLine;
			UpdateText();
		}
		// For debugging purposes, updates will be consolidated in general manager class later
		private void Update()
		{
			if (!_isDialogueActive) return;
			inputManager.GetPlayerInput();
		}
		
		private void NextLine()
		{
			if (_isDialogueFinished) return;
			if (_isDialogueSkippable) _dialogueIndex++;
			if (_dialogueIndex >= _dialogueText.Length)
			{
				_isDialogueFinished = true;
				_isDialogueActive = false;
				GEvents.playerAction -= NextLine;
				UpdateText();
			}
		}
		
		private void UpdateText()
		{
			_activeName.text = _dialogueNames[_dialogueIndex];
			_activeText.text = _dialogueText[_dialogueIndex];
			_activePortrait = _dialoguePortraits[_dialogueIndex];
		}
		
	}
}