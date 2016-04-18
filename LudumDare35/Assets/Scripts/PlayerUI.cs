using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	private Scrollbar hpBar;
	private Text scoreText;

	void Awake(){
		hpBar = this.GetComponentInChildren<Scrollbar> ();
		scoreText = this.GetComponentInChildren<Text> ();
	}

	void Update () {
	
	}

	public void updateLifeUI(int hpPlayer, int maxHp){
		hpBar.size = (float)hpPlayer / (float)maxHp;
	}

	public void updateScore(int value){
		scoreText.text = value.ToString ();
	}
}
