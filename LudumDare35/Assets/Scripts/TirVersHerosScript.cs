using UnityEngine;
using System.Collections;

public class TirVersHerosScript : MonoBehaviour {

	private Vector3 playerPosition;

	// Use this for initialization
	void Start () {

		playerPosition = new Vector3 (GameObject.Find ("Player").gameObject.transform.position.x, GameObject.Find ("Player").gameObject.transform.position.y, GameObject.Find ("Player").gameObject.transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {

		MoveTowardEnemy (Time.deltaTime);
	
	}

	public void MoveTowardEnemy (float temps)
	{
		transform.position = Vector3.Lerp(transform.position, playerPosition * 4, 0.5f * temps);
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.transform.tag == "Player") {
			GameObject.Find ("Player").GetComponent<PlayerManager>().takeDamage (5);
			Destroy (this.gameObject);
		}
	}
}
