using UnityEngine;
using System.Collections;

public class EnemyTeteChercheuse : EnemyScript {

	protected GameObject playa;

	void Awake () {
		playa = GameObject.FindWithTag ("Player").gameObject;
		manager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void Start(){
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-5f, 0f);
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
		} else if (coll.gameObject.tag == "startMob") {
			if (playa != null)
				this.GetComponent<Rigidbody2D> ().velocity = (playa.transform.position - transform.position).normalized * 12f;
			else
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-5f, 0f);
		} else if (coll.gameObject.tag == "Player") {
			coll.GetComponent<PlayerManager> ().takeDamage (2);
			Destroy (this.gameObject);
		}

	}
}
