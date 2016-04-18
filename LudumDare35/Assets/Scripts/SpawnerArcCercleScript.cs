using UnityEngine;
using System.Collections;

public class SpawnerArcCercleScript : MonoBehaviour {

	public bool Actif = false;

	public Transform EnemyArcCercle;

	public bool basEnHaut = false;

	public int compteur = 4;  
	private int cpt;

	private float chrono = 1f;
	private float maxChrono = 1f;

	private float positionXSpawn = 5;


	void Start () {
		cpt = compteur;
	}
	
	// Update is called once per frame
	void Update () {
		chrono -= Time.deltaTime;
		if (Actif && (chrono <= 0)) {
			if (cpt > 0) {
				doSpawnOneMob ();
				cpt -= 1;
			}
			if (cpt == 0) {
				Actif = false;
				cpt = compteur;
			}
			chrono = maxChrono;
		}
	}

	public void doSpawnOneMob()
	{
		var Enemy1 = Instantiate (EnemyArcCercle) as Transform;
		Vector3 newPos = new Vector3 (positionXSpawn, this.transform.position.y, this.transform.position.z);
		Enemy1.position = newPos;
		Enemy1.SetParent (this.transform);
		if (basEnHaut) {
			Enemy1.GetComponent<EnemyArcCercleScript> ().BasEnHaut = true;
		}
	}

	public void setSequenceArc(int compteur, float timeBetweenInstance){
		this.compteur = compteur;
		maxChrono = timeBetweenInstance;
		positionXSpawn = Random.Range (6f, 10f);
		Actif = true;
	}
}
