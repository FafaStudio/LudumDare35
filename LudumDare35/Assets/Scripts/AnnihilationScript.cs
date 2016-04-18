﻿using UnityEngine;
using System.Collections;

public class AnnihilationScript : MonoBehaviour {


	private float chrono = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		chrono -= Time.deltaTime;

		if (chrono <= 0)
			Destroy (this.gameObject);

	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name.Contains("Clone") && coll.gameObject.tag != "Player") {
			print (coll.name);
			Destroy (coll.gameObject);
		}
	}

	public void destroy()
	{
		Destroy (this.gameObject);
	}
}
