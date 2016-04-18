using UnityEngine;


public class MovementScript : MonoBehaviour
{

	public Vector2 speed;

	public float savedSpeedX;
	public float savedSpeedY;

	public Vector2 direction;

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
		body.velocity = movement;
	}

	void OnPauseGame(){
		savedSpeedX = speed.x;
		savedSpeedY = speed.y;
		speed.x = 0f;
		speed.y = 0f;
	}

	void OnResumeGame(){
		speed.x = savedSpeedX;
		speed.y = savedSpeedY;
	}
}