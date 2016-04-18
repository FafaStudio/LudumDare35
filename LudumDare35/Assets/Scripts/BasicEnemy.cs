using UnityEngine;
using System.Collections;

public class BasicEnemy : EnemyScript {

	private WeaponManager weapon;
	private float maxRate;

	void Start () {
		weapon = this.GetComponent<WeaponManager> ();
		maxRate = weapon.shootingRate;
	}

	void Update () {
		weapon.shootingRate -= Time.deltaTime;
		if (weapon.shootingRate <= 0) {
			doAttack ();
		}
	}

	private void doAttack(){
		if(weapon!=null){
			weapon.Attack (true);
			weapon.shootingRate = maxRate;
		}
	}

	void OnPauseGame(){
		this.enabled = false;
	}

	void OnResumeGame(){
		this.enabled = true;
	}
}
