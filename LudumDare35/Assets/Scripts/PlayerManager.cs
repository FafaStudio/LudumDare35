using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	//VARIABLES______________________________________________________________________________________________________________

	public Vector2 speed = new Vector2(20f, 20f); 
	private float movementX = 10f;
	private float movementY = 10f;
	public int maxPv;
	private int curPv;

	private PlayerUI uiPlayer;

	private Animator animManager;

	private WeaponManager[] weapon;

	public Vector2 movement;

	public int levelHero;

	private bool isDead = false;

	public int cptPowerUp = 0;

	Rigidbody2D body;
	public GameObject nextTransformation;

	private SpawnChief spawner;

	private CameraManager camera;
	public GameObject explosion;


	//AWAKE, START, UPDATE...______________________________________________________________________________________________
	void Awake(){
		spawner = GameObject.Find("Spawner").GetComponent<SpawnChief>();
		uiPlayer = GameObject.Find ("UI").GetComponent<PlayerUI> ();
		camera = GameObject.FindWithTag ("MainCamera").GetComponent<CameraManager> ();
	}
	void Start () {
		animManager = this.GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
		weapon = this.GetComponents<WeaponManager> ();
		if (levelHero <2) {
			for (int i = 0; i < weapon.Length; i++) {
				this.weapon [i].shotPrefab.localScale = new Vector3 (1f, 1f, 1f);
			}
		}
		curPv = maxPv;
		uiPlayer.updateLifeUI (curPv, maxPv);
	}

	void Update () {
		if (isDead)
			return;
		calculMovement ();
		shoot ();
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
	}

	void FixedUpdate(){
		doMovement ();
	}


	//MOVEMENT________________________________________________________________________________________________________________

	private void calculMovement(){
		if (Input.GetKey (KeyCode.D)) {
			animManager.SetInteger ("Position", 1);
			speed.x = movementX;
		} else if (Input.GetKey (KeyCode.Q)) {
			animManager.SetInteger ("Position", -1);
			speed.x = -movementX;
		} else {
			animManager.SetInteger ("Position", 0);
			speed.x = 0;
		}

		if (Input.GetKey (KeyCode.Z))
			speed.y = movementY;
		else if (Input.GetKey (KeyCode.S))
			speed.y = -movementY;
		else
			speed.y = 0;
	}
	private void doMovement(){
		body.velocity = speed;
	}

	//GESTION VIE________________________________________________________________________________________________________________

	public void takeDamage(int nbr)
	{
		this.curPv -= nbr;
		camera.setShake (0.3f);
		uiPlayer.updateLifeUI (curPv, maxPv);
		testEstMort ();

	}

	public void testEstMort()
	{
		if (this.curPv <= 0) {
			if (nextTransformation != null) {
				StartCoroutine (launchShapeshift ());
			} else if (levelHero == 3) {
				StartCoroutine (launchFinalDeath ());
			}
		}

	}

	public IEnumerator launchShapeshift(){
		camera.setShake (1.2f);
		spawner.maxCompteurWave = 5f;
		var explo = Instantiate (explosion.transform, this.transform.position, Quaternion.identity) as Transform;
		animManager.SetBool ("isDead", true);
		yield return new WaitForSeconds (0.3f);
		GameObject nextTransfo = Instantiate (nextTransformation, this.transform.position, Quaternion.identity) as GameObject;
		Destroy (this.gameObject);
	}

	public IEnumerator launchFinalDeath(){
		isDead = true;
		var explo = Instantiate (explosion.transform, this.transform.position, Quaternion.identity) as Transform;
		animManager.SetBool ("isDead", true);
		spawner.playerIsDead = true;
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}

	//COLLISION________________________________________________________________________________________________________________

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "PowerUp") {
			cptPowerUp++;
			if ((cptPowerUp > 4)||(levelHero>2))
				return;
			spawner.maxCompteurWave = 5f - cptPowerUp;
			for (int i = 0; i < weapon.Length; i++) {
				this.weapon [i].shotPrefab.localScale = new Vector3 (weapon [i].shotPrefab.localScale.x + 0.2f, weapon [i].shotPrefab.localScale.y + 0.2f, weapon [i].shotPrefab.localScale.z);
				this.weapon [i].shootingRate -= 0.025f;
			}
			Destroy (col.gameObject);
		}
		 else if (col.gameObject.tag == "TIREnemy") {
			takeDamage (col.GetComponent<ShotScript> ().damage);
			StartCoroutine (col.gameObject.GetComponent<ShotScript> ().startEnd ());
		}
	}


	public void shoot(){
		if (Input.GetKey (KeyCode.Space)) {
			animManager.SetBool ("Firing", true);
			if (weapon.Length != 0)
			{
				for (int i = 0; i < weapon.Length; i++) {
					weapon[i].AttackWithCustomPosition (this.levelHero);
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.Space))
			animManager.SetBool("Firing", false);
	} 

}

