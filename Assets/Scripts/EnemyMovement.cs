using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public int size;
	public bool ignoreColorChange;
	public Sprite red;
	public Sprite green;


	void Start () 
	{
		if (gameObject.tag == "red" && size == 32)
		{
			ignoreColorChange = true;
			gameObject.collider2D.isTrigger = false;
		}
	}


	void FixedUpdate () 
	{
		ChangeColor();
	}


	private void ChangeColor()
	{
		if (ignoreColorChange == false)
		{
			// at respawn make green bigger enemies red
			if(PointSystem.level == 0 
			   && gameObject.tag == "green" && size > 1)
				GreenToRed();

			// make red smaller enemies green
			if (gameObject.tag == "red")
			{
				if((PointSystem.level == 1 && size < 4)
				   || (PointSystem.level == 2 && size < 8)
				   || (PointSystem.level == 3 && size < 16)
				   || (PointSystem.level == 4 && size <32))
					RedToGreen();
			}
		}
	}


	// change isTrigger every time color changes
	// green enemies have triggers, red enemies don't
	private void RedToGreen()
	{
		GetComponent<SpriteRenderer>().sprite = green;
		gameObject.collider2D.isTrigger = true;
		gameObject.tag = "green";
	}

	private void GreenToRed()
	{
		GetComponent<SpriteRenderer>().sprite = red;
		gameObject.collider2D.isTrigger = false;
		gameObject.tag = "red";
	}
}
