using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling
/// </summary>
public class ScrollingScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(10, 10);
	private Vector2 direction = new Vector2(-1, 0);
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

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "EndScrolling") {
			this.transform.position = GameObject.Find ("StartScrolling").transform.position;
		}
	}
}
