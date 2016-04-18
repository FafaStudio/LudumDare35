using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int score = 0;
	private PlayerUI uiDisplay;

	public bool isPaused = false;

	void Start () {
		uiDisplay = GameObject.Find ("UI").GetComponent<PlayerUI> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
		if (isPaused)
			resumeGame ();
		else
			launchPaused ();
	}

	public void updateScore(int value){
		score += value;
		uiDisplay.updateScore (score);
	}

	//PAUSE_____________________________________________________________________________________________________________

	public void launchPaused(){
		isPaused = true;
		//musicLauncher.volume = 0.4f;
		//player.ui.pausePanel.SetActive (true);
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void resumeGame(){
		isPaused = false;
		//musicLauncher.volume = 1f;
		//	player.ui.pausePanel.SetActive (false);
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
		}
	}
}
