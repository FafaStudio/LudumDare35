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
		x = 1;
		y = 0;
		xDirection = false;
		this.pv = 5;
		chrono = maxChrono;

	}
	
	// Update is called once per frame
	void Update () {

		if (!xDirection) {
			x = x + 0.015f;
			if (x >3.0f) {

				xDirection = true;
			}
		} else {
			x = x - 0.05f;

		}

		y = y + 0.02f;


		if ((x < 0) && (y > 6)) {
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
				shotTransformEnemy.GetComponent<MovementScript> ().direction = new Vector2(playa.transform.position.x,playa.transform.position.y);
				chrono = maxChrono;
			}
		}
	
	}



	public void doDeplacementEnemyArcCercle(Vector3 direction) {

		transform.Translate (direction * 0.025f);
	}
}
