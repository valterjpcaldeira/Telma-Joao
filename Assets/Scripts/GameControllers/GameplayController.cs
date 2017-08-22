using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private Button restartButton;

	[SerializeField]
	private Text scoretext, pauseText;

	private int score;
	private string METERS_LABEL = "M";
	private string SCORE_NAME = "Score";
	private string IS_READY = "Ready";
	private string END_MESSAGE = "GameOver";
	private string PAUSE_MESSAGE = "Pause";
	public string IS_READY_MESSAGE = "Joao's Ready";
	private string JOGO = "Gameplay";
	private string MAIN_MENU = "MainMenu";

	public string name = "Joao";


	void Start () {
		updateScoreText ();
		StartCoroutine (CountScore());
	}
	
	IEnumerator CountScore(){
		yield return new WaitForSeconds (0.6f);
		score++;
		updateScoreText ();
		StartCoroutine (CountScore());
	}

	private void updateScoreText(){
		scoretext.text = score + METERS_LABEL;
	}

	void OnEnable(){
		PlyerDied.endGame += PlayerDiedEndTheGame;
		PlayerIsReady.isReady += PlayerIsReadyGame;
	}

	void OnDisable(){
		PlyerDied.endGame -= PlayerDiedEndTheGame;
		PlayerIsReady.isReady -= PlayerIsReadyGame;
	}

	void PlayerIsReadyGame(){


		PlayerPrefs.SetInt (name+IS_READY, 1);

		string auxName = name;

		if (name.Equals ("Joao")) {
			auxName = "João";
		}

		pauseText.text = IS_READY_MESSAGE;

		pausePanel.SetActive (true);
		restartButton.onClick.RemoveAllListeners ();
		restartButton.onClick.AddListener (() => ResumeGame());
		Time.timeScale = 0f;
	}


	void PlayerDiedEndTheGame(){

		if (!PlayerPrefs.HasKey (name+SCORE_NAME)) {
			PlayerPrefs.SetInt (name+SCORE_NAME, 0);
		} else {
			int highScore = PlayerPrefs.GetInt (name+SCORE_NAME);
			if (highScore < score) {
				PlayerPrefs.SetInt (name+SCORE_NAME, score);
			}
		}

		pauseText.text = END_MESSAGE;

		pausePanel.SetActive (true);
		restartButton.onClick.RemoveAllListeners ();
		restartButton.onClick.AddListener (() => RestarGame());
		Time.timeScale = 0f;
	}

	public void RestarGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (JOGO+name);
	}



	public void PauseButton(){
		pauseText.text = PAUSE_MESSAGE;
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartButton.onClick.RemoveAllListeners ();
		restartButton.onClick.AddListener (() => ResumeGame());
	}
	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void GoToMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (MAIN_MENU);
	}


}
