using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

	public Text scoreText;
	public Text highscoreText;
	private bool gameOver;
	private int score;
	int highscore;
	public float highscoreCount;
	public Button[] buttons;
	private bool restart;


	void Start (){
		if (PlayerPrefs.GetFloat ("HIGHEST") != null) {
			highscoreCount = PlayerPrefs.GetFloat ("HIGHEST");
		}

		gameOver = false;
		score = 0;
		highscore = PlayerPrefs.GetInt ("SCORE",highscore);
		UpdateScore ();
	}

	void Update (){
		if (score > highscoreCount) {
			highscoreCount = score;
			PlayerPrefs.SetFloat ("HIGHEST", highscoreCount);
		}
		highscoreText.text = "HIGHEST: " + Mathf.Round (highscoreCount);

	
	}



	public void AddScore (int newScoreValue){

		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore (){

		scoreText.text = "SCORE: " + score;
	}

	public void GameOver(){

		gameOver = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);

		}

	}
	public void Play(){
		SceneManager.LoadScene ("one");	
	}

	public void Pause(){

		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} 
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}
	public void Menu(){

		SceneManager.LoadScene ("menu");
	}
	public void Exit(){
		Application.Quit ();

	}
}