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


	//AWAKE, START, UPDATE...______________________________________________________________________________________________

	void Start () {
		spawner = GameObject.Find("Spawner").GetComponent<SpawnChief>();
		uiPlayer = GameObject.Find ("UI").GetComponent<PlayerUI> ();
		animManager = this.GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
		weapon = this.GetComponents<WeaponManager> ();
		if (levelHero != 3) {
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
	private void doMovement(){
		body.velocity = speed;
	}

	//GESTION VIE________________________________________________________________________________________________________________

	public void takeDamage(int nbr)
	{
		this.curPv -= nbr;
		uiPlayer.updateLifeUI (curPv, maxPv);
		testEstMort ();

	}

	public void testEstMort()
	{
		if (this.curPv <= 0) {
			if (nextTransformation != null) {
				spawner.maxCompteurWave = 5f;
				Instantiate (nextTransformation, this.transform.position, Quaternion.identity);
				Destroy (this.gameObject);
			} else if (levelHero == 3) {
				StartCoroutine (launchDeath ());
			}
		}

	}

	public IEnumerator launchDeath(){
		isDead = true;
		animManager.SetBool ("isDead", true);
		spawner.playerIsDead = true;
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}

	//COLLISION________________________________________________________________________________________________________________

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "PowerUp") {
			cptPowerUp++;
			if (cptPowerUp > 4)
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

