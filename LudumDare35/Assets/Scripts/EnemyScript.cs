using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int pv;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
			
	
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "TIRPlayer") {
			this.pv -= 1;
			Destroy (coll.gameObject);
			if (this.pv <= 0) {
				Destroy (this.gameObject);
			}
		}

	}
}
