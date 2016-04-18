using UnityEngine;
using System.Collections;

public class EnemyTeteChercheuse : EnemyScript {

	protected GameObject playa;
	private bool cherche = false;

	void Awake () {
		playa = GameObject.FindWithTag ("Player").gameObject;
		manager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void Start(){
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-5f, 0f);
	}

	void Update(){

		if (cherche)
			this.GetComponent<Rigidbody2D> ().velocity = (playa.transform.position - this.transform.position).normalized * 5f;

		this.transform.rotation = Quaternion.Euler (0f, 0f, 180 + (Mathf.Atan2((playa.transform.position.y - this.transform.position.y), (playa.transform.position.x - this.transform.position.x)) * Mathf.Rad2Deg));

	}
	
	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "TIRPlayer") {
			this.pv -= 1;
			StartCoroutine (coll.gameObject.GetComponent<ShotScript> ().startEnd ());
			if (this.pv <= 0) {
				manager.updateScore (scoreValue);
				Destroy (this.gameObject);
			}
		} else if (coll.gameObject.tag == "startMob") {
			if (playa != null)
				cherche = true;
			else
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-5f, 0f);
		} else if (coll.gameObject.tag == "Player") {
			coll.GetComponent<PlayerManager> ().takeDamage (2);
			Destroy (this.gameObject);
		}

	}
}
