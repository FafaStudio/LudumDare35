﻿using UnityEngine;
using System.Collections;

public class EnemyArcCercleScript : EnemyScript {

	public float x;
	public float y;
	public bool xDirection;
	public bool BasEnHaut;
	public Transform tirEnemy;
	private float chrono;
	private float maxChrono = 0.5f;

	protected GameObject playa;

	private Animator anim;

	void Awake () {
		anim = this.GetComponent<Animator> ();
		playa = GameObject.FindWithTag ("Player").gameObject;
		manager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void Start () {
		x = 0.5f;
		y = 0;
		xDirection = false;
		this.pv = 5;
		chrono = maxChrono;
	}


	void Update () {
		if (!xDirection) {
			x = x + 0.02f;
			if (x >2f) {

				xDirection = true;
			}
		} else {
			x = x - 0.02f;

		}
		y = y + 0.01f;
		if ((x < 0) && (y > 10)) {
			Destroy (this.gameObject);
		}
		if (BasEnHaut) {
			doDeplacementEnemyArcCercle (new Vector3 (-x, y, 1));
		} else {
			doDeplacementEnemyArcCercle (new Vector3 (-x, -y, 1));
		}
		chrono -= Time.deltaTime;
		if ((this.transform.position.x < 7.5f) && (this.transform.position.x > -7.5f) && (this.transform.position.y < 4) && (this.transform.position.y > -4)) {
			if (chrono <= 0) {
				anim.SetTrigger ("Firing");
				chrono = maxChrono;
				var instantiatedProjectile = Instantiate(tirEnemy,transform.position,transform.rotation)as Transform;
				instantiatedProjectile.SetParent (manager.transform);
				if (playa != null) {
					instantiatedProjectile.rotation = Quaternion.Euler (0f, 0f, 180 + (Mathf.Atan2 ((playa.transform.position.y - this.transform.position.y), (playa.transform.position.x - this.transform.position.x)) * Mathf.Rad2Deg));
					instantiatedProjectile.GetComponent<Rigidbody2D> ().velocity = (playa.transform.position - transform.position).normalized * 8f;
				}
				else
					instantiatedProjectile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-10f, 0f);
			}
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
		this.transform.localScale = new Vector3 (0.4f, 0.4f);
		yield return new WaitForSeconds (0.2f);
		Destroy (this.gameObject);
	}


	public void doDeplacementEnemyArcCercle(Vector3 direction) {
		transform.Translate (direction * 0.025f);
	}
}
