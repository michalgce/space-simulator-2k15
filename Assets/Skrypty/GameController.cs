using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		gameOverText.SetActive (false);
	}

	void Update ()
	{
		if (gameOver)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				restart = true;
			}
		}
		if (restart) {
			Application.LoadLevel (Application.loadedLevel);
			restart = false;
			gameOver = false;
			Time.timeScale = 1;
		}
	}

	public void GameOver ()
	{
		gameOver = true;
		gameOverText.SetActive (true);
		Time.timeScale = 0;
	}
}