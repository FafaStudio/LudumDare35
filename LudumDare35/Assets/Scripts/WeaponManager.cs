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

			// On saisit la direction pour le mouvement
			MovementScript move = shotTransform.gameObject.GetComponent<MovementScript>();
			if (move != null)
			{
				if (shot.isEnemyShot)
					return;
				move.direction = this.transform.right; // ici la droite sera le devant de notre objet
			}
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}