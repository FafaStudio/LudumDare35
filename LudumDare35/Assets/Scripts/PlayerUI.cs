using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public GameManager manager;

	private Scrollbar hpBar;
	private Text scoreText;

	private GameObject pausePanel;

	private bool isPaused = false;

	public Button[] pauseButton;
	private int cptPauseMenu = 0;

	void Awake(){
		pausePanel = GameObject.Find ("pausePanel");
		pausePanel.SetActive (false);
		hpBar = this.GetComponentInChildren<Scrollbar> ();
		scoreText = this.GetComponentInChildren<Text> ();
	}

	void Update () {
		if (!isPaused)
			return;
		if (Input.GetKeyDown (KeyCode.Z)){
			cptPauseMenu--;
			if (cptPauseMenu < 0) 
				cptPauseMenu = 2;
			pauseButton [cptPauseMenu].Select ();	 
		}
		else if (Input.GetKeyDown (KeyCode.S)){
			cptPauseMenu++;
			if (cptPauseMenu > 2) 
				cptPauseMenu = 0;
			pauseButton [cptPauseMenu].Select ();
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			switch (cptPauseMenu) {
			case 0:
				manager.resumeGame ();
				break;
			case 1:
				break;
			case 2:
				Application.Quit();
				break;
			}
		}
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
