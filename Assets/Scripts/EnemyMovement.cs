using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	private Vector2 newPosition;


	void Start () 
	{
		InvokeRepeating("MoveLeft", 2F, Random.Range(0.1F, 3.5F));
	}


	void Update()
	{
		// if enemy is beyond bounds of the screen
		if (gameObject.name.Contains ("Clone") 
		    && (gameObject.transform.position.x <= -3.6F - gameObject.collider2D.bounds.size.x
		    || gameObject.transform.position.x == 3.8F
		    || gameObject.transform.position.y == -2.4F))
			Destroy(gameObject);
	}


	// enemy moves left
	void MoveLeft()
	{
		newPosition = gameObject.transform.position;
		if (gameObject.name.Contains ("Clone"))
			newPosition.x -= 0.2F;
		gameObject.transform.position = newPosition;
	}
}
