using UnityEngine;


public class WeaponManager : MonoBehaviour
{

	public Transform shotPrefab;

	public float shootingRate = 0.25f;

	private float shootCooldown;

	void Start()
	{
		shootCooldown = 0f;
	}

	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
		
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.position = transform.position;

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
				if (!shot.isEnemyShot) {
					Vector3 bullPosition = new Vector3 (transform.position.x + 1f, transform.position.y-0.1f, 0f);
					shotTransform.position = bullPosition;
				}
			}
		}
	}

	public void AttackWithCustomPosition(int level){
		if (CanAttack) {
			shootCooldown = shootingRate;
			var shotTransform = Instantiate (shotPrefab) as Transform;
			shotTransform.position = transform.position;

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript> ();
			if (shot != null)
				shotTransform.position = chooseStartPosition (level);
		}
	}

	public Vector3 chooseStartPosition(int level){
		Vector3 bullPosition = new Vector3 (transform.position.x + 1f, transform.position.y, 0f);;
		switch(level){
		case 0:
			bullPosition = new Vector3 (transform.position.x + 1f, transform.position.y - 0.1f, 0f);
			return bullPosition;
		case 1:
			bullPosition = new Vector3 (transform.position.x + 1.2f, transform.position.y - 0.3f, 0f);
			return bullPosition;
		case 2:
			bullPosition = new Vector3 (transform.position.x + 1f, transform.position.y - 0.1f, 0f);
			return bullPosition;
		case 3:
			bullPosition = new Vector3 (transform.position.x + 1f, transform.position.y +0.5f, 0f);
			return bullPosition;
		}
		return bullPosition;
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}