using UnityEngine;
using System.Collections;

public class EnemyArcCercleScript : EnemyScript {

	public float x;
	public float y;
	public bool xDirection;
	public bool BasEnHaut;
	public Transform tirEnemy;
	private float chrono;
	private float maxChrono = 0.5f;
	private GameObject playa;



	void Awake () {
		playa = GameObject.Find ("Player").gameObject;
	}
	// Use this for initialization
	void Start () {
		x = 0.5f;
		y = 0;
		xDirection = false;
		this.pv = 5;
		chrono = maxChrono;

	}
	
	// Update is called once per frame
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
				var shotTransformEnemy = Instantiate(tirEnemy, this.transform.position, Quaternion.identity) as Transform;
<<<<<<< HEAD
				shotTransformEnemy.GetComponent<MovementScript> ().direction = new Vector2(playa.transform.position.x,playa.transform.position.y);
=======
				//print (new Vector2(playa.transform.position.x, playa.transform.position.y));
>>>>>>> 98d35f9e55fe77d0ac3456417c90654dff0566fe
				chrono = maxChrono;
			}
		}
	
	}



	public void doDeplacementEnemyArcCercle(Vector3 direction) {

		transform.Translate (direction * 0.025f);
	}
}
