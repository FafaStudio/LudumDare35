using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {
	//private Text scoreText;

	public GameObject tutoPanel;
	public GameObject mainPanel;

	public Button[] mainButton;
	private int cptMainMenu = 0;

	private bool isTuto = false;

	void Awake(){
		tutoPanel.SetActive (false);
	}

	void Update () {
		if (!isTuto) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				cptMainMenu--;
				if (cptMainMenu < 0)
					cptMainMenu = 2;
				mainButton [cptMainMenu].Select ();	 
			} else if (Input.GetKeyDown (KeyCode.S)) {
				cptMainMenu++;
				if (cptMainMenu > 2)
					cptMainMenu = 0;
				mainButton [cptMainMenu].Select ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				switch (cptMainMenu) {
				case 0:
					SceneManager.LoadScene ("Game");
					break;
				case 1:
					if (!isTuto) {
						mainPanel.SetActive (false);
						tutoPanel.SetActive (true);
						isTuto = true;
					}
					break;
				case 2:
					Application.Quit ();
					break;
				}
			}
		} else {
			if ((Input.GetKeyDown (KeyCode.Space))||(Input.GetKeyDown (KeyCode.Escape))) {
				mainPanel.SetActive (true);
				tutoPanel.SetActive (false);
				isTuto = false;
			}
		}
	}
}
