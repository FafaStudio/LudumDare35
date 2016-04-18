using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int score = 0;
	private PlayerUI uiDisplay;

	void Start () {
		uiDisplay = GameObject.Find ("UI").GetComponent<PlayerUI> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateScore(int value){
		score += value;
		uiDisplay.updateScore (score);
	}
}
