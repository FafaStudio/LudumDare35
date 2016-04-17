using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	//VARIABLES______________________________________________________________________________________________________________

	public Vector2 speed = new Vector2(20f, 20f); 
	private float movementX = 10f;
	private float movementY = 10f;

	private Animator animManager;

	private WeaponManager weapon;

	//private float inputX = 0f;
	//private float inputY = 0f;

	public Vector2 movement;

	Rigidbody2D body;


	//AWAKE, START, UPDATE...______________________________________________________________________________________________

	void Start () {
		animManager = this.GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
		weapon = this.GetComponent<WeaponManager> ();
		this.weapon.shotPrefab.localScale = new Vector3 (1f, 1f, 1f);

	}

	void Update () {
		calculMovement ();
		shoot ();

		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
	}

	void FixedUpdate(){
		doMovement ();
	}


	//MOVEMENT________________________________________________________________________________________________________________

	private void calculMovement(){
		if (Input.GetKey (KeyCode.D))
			speed.x = movementX;
		else if (Input.GetKey (KeyCode.Q))
			speed.x = -movementX;
		else
			speed.x = 0;

		if (Input.GetKey (KeyCode.Z))
			speed.y = movementY;
		else if (Input.GetKey (KeyCode.S))
			speed.y = -movementY;
		else
			speed.y = 0;
	}

	/*private void calculMovement(){

		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		

		if (inputX != 0) {
			isMoving = true;
			if (inputX < 0)
				speed.x = -movementX;
			else
				speed.x = movementX;
		} else
			speed.x = 0f;

		if (inputY != 0) {
			isMoving = true;
			if (inputY < 0)
				speed.y = -movementY;
			else
				speed.y = movementY;
		} else
			speed.y = 0f;
	}*/

	private void doMovement(){
		body.velocity = speed;
	}

	//COLLISION________________________________________________________________________________________________________________

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "PowerUp") {
			this.weapon.shotPrefab.localScale = new Vector3 (weapon.shotPrefab.localScale.x + 0.2f, weapon.shotPrefab.localScale.y + 0.2f, weapon.shotPrefab.localScale.z);
			Destroy (col.gameObject);
		}
	}


	public void shoot(){
		if (Input.GetKey (KeyCode.Space)) {
			animManager.SetBool ("Firing", true);
			WeaponManager weapon = GetComponent<WeaponManager>();
			if (weapon != null)
			{
				weapon.Attack(false);
			}
		}
		if(Input.GetKeyUp(KeyCode.Space))
			animManager.SetBool("Firing", false);
	} 

}

