using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {

	public GameManager manager;

	private Scrollbar hpBar;
	private Text scoreText;

	private GameObject pausePanel;

	public GameObject gameOverPanel;

	public bool isGameOver= false;

	private bool isPaused = false;

	public Button[] pauseButton;
	private int cptPauseMenu = 0;

	public Button[] overButton;
	private int cptOverMenu = 0;

	public Text highScore;

	void Awake(){
		pausePanel = GameObject.Find ("pausePanel");
		pausePanel.SetActive (false);
		gameOverPanel.SetActive (false);
		hpBar = this.GetComponentInChildren<Scrollbar> ();
		scoreText = this.GetComponentInChildren<Text> ();
	}

	void Update () {
		if (!isGameOver) {
			if (!isPaused)
				return;
			if (Input.GetKeyDown (KeyCode.Z)) {
				cptPauseMenu--;
				if (cptPauseMenu < 0)
					cptPauseMenu = 1;
				pauseButton [cptPauseMenu].Select ();	 
			} else if (Input.GetKeyDown (KeyCode.S)) {
				cptPauseMenu++;
				if (cptPauseMenu > 1)
					cptPauseMenu = 0;
				pauseButton [cptPauseMenu].Select ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				switch (cptPauseMenu) {
				case 0:
					manager.resumeGame ();
					break;
				case 1:
					Application.Quit ();
					break;
				}
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Z)) {
				cptOverMenu--;
				if (cptOverMenu < 0)
					cptOverMenu = 1;
				overButton [cptOverMenu].Select ();	 
			} else if (Input.GetKeyDown (KeyCode.S)) {
				cptPauseMenu++;
				if (cptOverMenu > 1)
					cptOverMenu = 0;
				overButton [cptOverMenu].Select ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				switch (cptOverMenu) {
				case 0:
					SceneManager.LoadScene ("Game");
					break;
				case 1:
					Application.Quit ();
					break;
				}
			}
		}
	}

	public void launchGameOver(int Score){
		gameOverPanel.SetActive (true);
		highScore.text = Score.ToString();
		isGameOver = true;
	}

	public void updateLifeUI(int hpPlayer, int maxHp){
		hpBar.size = (float)hpPlayer / (float)maxHp;
	}

	public void updateScore(int value){
		scoreText.text = value.ToString ();
	}

	void OnPauseGame(){
		pausePanel.SetActive (true);
		cptPauseMenu = 0;
		pauseButton [0].Select ();
		isPaused = true;
	}

	void OnResumeGame(){
		pausePanel.SetActive (false);
		isPaused = false;
	}

}
