using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is for restarting the game.
 */
public class RestartLevel : MonoBehaviour
{

	// Update is called once per frame
	void Update()
	{
		// when the player presses the R button on the keyboard the game will then restart to its 
		//original form from when you first started it. also when you win or lose the game you can 
		//press the letter R on the keyboard and it will restart.
		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerScore.playerScore = 0;
			GameOver.isPlayerDead = false;
			Time.timeScale = 1;

			SceneManager.LoadScene("SampleScene");
		}
	}
}