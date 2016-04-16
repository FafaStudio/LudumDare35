using UnityEngine;


public class MovementScript : MonoBehaviour
{

	public Vector2 speed = new Vector2(10, 10);


	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;

	private Rigidbody2D body;

	public void Awake(){
		body = this.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// Application du mouvement
		body.velocity = movement;
	}
}