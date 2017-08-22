using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	private string SCORE_JOAO = "JoaoScore";
	private string SCORE_TELMA = "TelmaScore";
	private string JOAO_IS_READY = "JoaoReady";
	private string TELMA_IS_READY = "TelmaReady";
	private string METERS_LABEL = "M";

	[SerializeField]
	private Text joaoHighScore;
	[SerializeField]
	private Text telmaHighScore;
	[SerializeField]
	private GameObject secretButton;


	public void Start(){
		int highScore = PlayerPrefs.GetInt (SCORE_JOAO);
		joaoHighScore.text = highScore + METERS_LABEL;
		int highScoreTelma = PlayerPrefs.GetInt (SCORE_TELMA);
		telmaHighScore.text = highScoreTelma + METERS_LABEL;
		int isTelmaReady = PlayerPrefs.GetInt (JOAO_IS_READY);
		int isJoaoready = PlayerPrefs.GetInt (TELMA_IS_READY);
		if (isJoaoready + isTelmaReady > 1) {
			secretButton.SetActive(true);
		}
	}

	public void PlayGame(){
		SceneManager.LoadScene ("GameplayJoao");
	}

	public void PlayGameTelma(){
		SceneManager.LoadScene ("GameplayTelma");
	}

	public void PlayGameSecret(){
		SceneManager.LoadScene ("GameplaySecret");
	}
}
