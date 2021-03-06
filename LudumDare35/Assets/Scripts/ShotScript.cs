﻿using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;

	public bool isEnemyShot = false;

	public Sprite touchSprite;

	private bool isTouching = false;

	private Vector2 savedVelocity;

	void Start()
	{
		savedVelocity = this.GetComponent<Rigidbody2D> ().velocity;
	}

	void Update(){
		if (!isTouching)
			return;
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "EndBullet")
			Destroy (this.gameObject);
	}

	public IEnumerator startEnd(){
		if (this.gameObject == null)
			yield return null;
	
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
		if (this.GetComponent<Animator> () != null) {
			Destroy (this.GetComponent<Animator> ());
		}
		//this.transform.localScale = new Vector3(1f, 1f,1f);
		if (touchSprite != null) {
			this.GetComponent<SpriteRenderer> ().sortingLayerName = "EndMunition";
			this.GetComponent<SpriteRenderer> ().sprite = touchSprite;
		}
		yield return new WaitForSeconds (0.005f);
		isTouching = true;
	}

	void OnPauseGame(){
		savedVelocity = this.GetComponent<Rigidbody2D> ().velocity;
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
		this.enabled = false;
	}

	void OnResumeGame(){
		this.GetComponent<Rigidbody2D> ().velocity = savedVelocity;
		this.enabled = true;
	}
}
