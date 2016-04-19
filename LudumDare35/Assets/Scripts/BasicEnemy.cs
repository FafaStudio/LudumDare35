using UnityEngine;
using System.Collections;

public class BasicEnemy : EnemyScript {

	private WeaponManager weapon;
	private float maxRate;

	private Animator anim;

	void Start () {
		anim = this.GetComponent<Animator> ();
		weapon = this.GetComponent<WeaponManager> ();
		maxRate = weapon.shootingRate;
	}

	void Update () {
		weapon.shootingRate -= Time.deltaTime;
		if (weapon.shootingRate <= 0) {
			doAttack ();
		}
	}

	private void doAttack(){
		if(weapon!=null){
			anim.SetTrigger ("Firing");
			weapon.Attack (true);
			weapon.shootingRate = maxRate;
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "TIRPlayer") {
			this.pv -= 1;
			StartCoroutine (coll.gameObject.GetComponent<ShotScript> ().startEnd ());
			if (this.pv <= 0) {
				manager.updateScore (scoreValue);
				StartCoroutine (launchDeath ());
			}
		}
	}

	public IEnumerator launchDeath(){
		anim.SetBool ("isDead", true);
		//this.transform.localScale = new Vector3 (0.4f, 0.4f);
		yield return new WaitForSeconds (0.2f);
		Destroy (this.gameObject);
	}

	void OnPauseGame(){
		this.enabled = false;
	}

	void OnResumeGame(){
		this.enabled = true;
	}
}
