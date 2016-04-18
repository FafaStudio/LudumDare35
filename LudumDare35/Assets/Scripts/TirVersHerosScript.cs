using UnityEngine;
using System.Collections;

public class TirVersHerosScript : MonoBehaviour {

	private Vector3 playerPosition;

	void Start () {
		playerPosition = new Vector3 (GameObject.Find ("Player").gameObject.transform.position.x, GameObject.Find ("Player").gameObject.transform.position.y, GameObject.Find ("Player").gameObject.transform.position.z);
	}

	void Update () {
	//	MoveTowardEnemy (Time.deltaTime);
	}

	public void MoveTowardEnemy (float temps)
	{
		transform.position = Vector3.Lerp(transform.position, playerPosition * 2f, 0.5f * temps);
	}
}
