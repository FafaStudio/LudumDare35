using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour {

	public Transform powerUp;
	public Transform enemyBasic;

	private float chronoPowerUp;
	private float chronoBasicEnemy;

	void Start () {
		chronoPowerUp = Random.Range (5f, 30f);
		chronoBasicEnemy = Random.Range (2f, 6f);

	}

	void Update () {
		chronoPowerUp -= Time.deltaTime;
		chronoBasicEnemy -= Time.deltaTime;
		spawnPowerUp ();
		spawnBasicEnnemy ();
	}

	public void spawnPowerUp(){
		if (chronoPowerUp <= 0f) {
			var puTransform = Instantiate(powerUp) as Transform;
			Vector3 newPos = new Vector3 (this.transform.position.x, Random.Range (-4f, 4f), 0f);
			puTransform.position = newPos;
			puTransform.SetParent (this.transform);
			chronoPowerUp = Random.Range (15f, 25f);
		}
	}

	public void spawnBasicEnnemy(){
		if (chronoBasicEnemy <= 0f) {
			var puTransform = Instantiate(enemyBasic) as Transform;
			Vector3 newPos = new Vector3 (this.transform.position.x, Random.Range (-4f, 4f), 0f);
			puTransform.position = newPos;
			puTransform.SetParent (this.transform);
			chronoBasicEnemy = Random.Range (2f, 6f);
		}
	}
}
