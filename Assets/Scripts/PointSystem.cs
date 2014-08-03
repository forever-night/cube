using UnityEngine;
using System.Collections;

public class PointSystem : MonoBehaviour 
{
	internal static int points, level;


	void Start () 
	{
		points = level = 0;
	}
	

	void FixedUpdate () 
	{
		LevelUp();
		// print("level: " + level + ", points: " + points);
	}


	internal static void AddPoints( Enemy enemy )
	{
		points += enemy.size;
	}


	internal static void LevelUp()
	{
		// DON'T use level++, method is called in FixedUpdate,
		//		level will be infinitely increasing
		// DON'T use switch(points),
		// 		won't give a result if number of points is between two levels
		level = points == 0 ? 0 : level;
		level = points >= 2 && points < 6 ? 1 : level;
		level = points >= 6 && points < 14 ? 2 : level;
		level = points >= 14 && points < 30 ? 3 : level;
		level = points >= 30 ? 4 : level;
	}
}
