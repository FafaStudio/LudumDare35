using UnityEngine;
using System.Collections;

public class SpawnChief : MonoBehaviour {

	private SpawnerManager[] spawnerFond;
	private SpawnerArcCercleScript[] spawnerArc;

	public float maxCompteurWave = 5f;
	private float compteur;

	public bool playerIsDead = false;

	void Start () {
		spawnerFond = this.GetComponentsInChildren<SpawnerManager> ();
		spawnerArc = this.GetComponentsInChildren<SpawnerArcCercleScript> ();
		compteur = maxCompteurWave;
	}
	

	void Update () {
		if (playerIsDead)
			return;
		compteur -= Time.deltaTime;
		if (compteur <= 0) {
			launchWaves ();
			compteur = maxCompteurWave;
		}
	}

	public void launchWaves(){
		int choice = Random.Range (0, 5);
		switch (choice) {
		case 0:
			spawnerFond[0].setSequence (5, 2f);
			spawnerArc [0].setSequenceArc (5, 2f);
			spawnerFond[1].setSequence (3, 2f);
			break;
		case 1:
			spawnerFond[0].setSequence (10, 3f);
			spawnerArc [1].setSequenceArc (5, 2f);
			break;
		case 2:
			spawnerArc [0].setSequenceArc (5, 2f);
			spawnerArc [1].setSequenceArc (5, 3f);
			spawnerFond[1].setSequence (4, 2f);
			break;
		case 3:
			spawnerFond[0].setSequence (10, 1f);
			break;
		case 4:
			spawnerFond[0].setSequence (3, 3f);
			spawnerArc [1].setSequenceArc (6, 2f);
			break;
		case 5:
			spawnerFond[0].setSequence (5, 2f);
			spawnerFond[1].setSequence (8, 1f);
			break;
		}
	}
}
