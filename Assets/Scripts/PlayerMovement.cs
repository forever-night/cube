using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private float unit = 0.2f;
	private Vector2 spawn;
	private Vector2 nextPosition;


	void Start () 
	{
		spawn = gameObject.transform.position;
	}
	

	void FixedUpdate () 
	{
		Movement();
	}


	void Movement()
	{
		nextPosition = rigidbody2D.position;

		nextPosition.y += unit * Input.GetAxisRaw ("Vertical");
		nextPosition.x += unit * Input.GetAxisRaw ("Horizontal");

		rigidbody2D.MovePosition (nextPosition);
		Input.ResetInputAxes ();
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "red")
		{
			gameObject.transform.position = spawn;
			PointSystem.points = 0;
		}
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "green")
		{
			EnemyMovement enemy = (EnemyMovement)collider.gameObject.GetComponent (typeof(EnemyMovement));

			try
			{
				PointSystem.AddPoints (enemy);
			}
			catch
			{
				print("couldn't get script, didn't get component");
			}

			Destroy(collider.gameObject);
		}
	}
}














