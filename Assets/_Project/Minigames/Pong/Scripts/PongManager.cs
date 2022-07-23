using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Minigames.Pong.Scripts
{
	public class PongManager : MonoBehaviour
	{
		[SerializeField] private Ball _ball;
		[SerializeField] private int _playerScore = 0;
		[SerializeField] private int _aiScore = 0;
		[SerializeField] private TextMeshProUGUI  _playerScoreText;
		[SerializeField] private TextMeshProUGUI _aiScoreText;

		//Singleton instance
		public static PongManager Instance;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		private void Start()
		{
			StartCoroutine(nameof(StartRound));
		}

		private IEnumerator StartRound()
		{
			yield return new WaitForSeconds(1f);
			_ball.InitializeMovement(new Vector2(1, 0));
		}
		public void Goal(bool player_goal)
		{
			if (player_goal)
			{
				_aiScore++;
			}
			else
			{
				_playerScore++;
			}
			_playerScoreText.text = _playerScore.ToString();
			_aiScoreText.text = _aiScore.ToString();
			_ball.ResetPosition();
			StartCoroutine(nameof(StartRound));
		}
	}
}