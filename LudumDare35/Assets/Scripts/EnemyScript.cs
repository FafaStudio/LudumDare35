using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int pv;
	public int scoreValue;

	protected GameManager manager;

	void Awake(){
		manager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "TIRPlayer") {
			this.pv -= 1;
			Destroy (coll.gameObject);
			if (this.pv <= 0) {
				manager.updateScore (scoreValue);
				Destroy (this.gameObject);
			}
		}

	}
}
