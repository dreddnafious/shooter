using UnityEngine;
using System.Collections;

/// <summary>
/// Game manager is a simple state machine that determines the over all flow of the game
/// what screen you're on, etc...
/// </summary>
public class GameManager : MonoBehaviour
{
	
	private enum GameState
	{
		Idle,
		Countdown,
		Playing
				
	}
	
	private GameState _gameState = GameState.Idle;

	// Use this for initialization
	void Start ()
	{
		_gameState = GameState.Playing;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch(_gameState)
		{
		case GameState.Idle:
			BeginCountdown();
			break;
		case GameState.Countdown:
			Countdown();
			break;
		case GameState.Playing:
			Playing();
			break;
			
		}//end switch
	
	}//end update()
	
	private void BeginCountdown()
	{
		_gameState = GameState.Countdown;
	}

	private void Countdown()
	{
		_gameState = GameState.Playing;
	}

	private void Playing()
	{

	}
}
