using UnityEngine;
using System.Collections;

public class SpawnerArcCercleScript : MonoBehaviour {

	public bool Actif = true;

	public Transform EnemyArcCercle;

	public bool basEnHaut = true;

	public int compteur = 4;  
	private int cpt;

	private float chrono = 1f;

	// Use this for initialization
	void Start () {
		cpt = compteur;
	
	}
	
	// Update is called once per frame
	void Update () {

		chrono -= Time.deltaTime;

		if (Actif && (chrono < 0)) {

			if (cpt > 0) {
				doSpawnOneMob ();
				cpt -= 1;
			}
			if (cpt == 0) {
				Actif = false;
				cpt = compteur;
			}
			chrono = 1f;
		}


				
	
	}

	public void doSpawnOneMob()
	{
		var Enemy1 = Instantiate (EnemyArcCercle) as Transform;
		Enemy1.position = this.transform.position;
		if (basEnHaut) {
			Enemy1.GetComponent<EnemyArcCercleScript> ().BasEnHaut = true;
		}

	}
}
