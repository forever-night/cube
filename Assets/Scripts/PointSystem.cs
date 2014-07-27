using UnityEngine;
using System.Collections;

public class PointSystem : MonoBehaviour 
{
	internal static int points;


	void Start () 
	{
		points = 0;
	}
	

	void FixedUpdate () 
	{
		 print(points);
	}


	public static void AddPoints( EnemyMovement enemy )
	{
		points += enemy.size;
	}
}
