using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour 
{
	GameObject[] enemies;
	int index;


	void Awake()
	{
		// creates pool of enemies
		enemies = new GameObject[] {
			GameObject.Find ("1e"), GameObject.Find ("1u"), 
			GameObject.Find ("4e"), GameObject.Find ("4u"), 
			GameObject.Find ("16e"), GameObject.Find ("16u"),
			GameObject.Find ("32u")};
	}


	void Start () 
    {
			index = Random.Range(0, enemies.Length);

		Instantiate(enemies[index], CreateVector(GenerateX(), GenerateY()), Quaternion.identity);
	}
	

	void FixedUpdate () 
    {
		// repeat every 5 seconds 
//		#region fixthis
//		index = Random.Range (0, enemies.Length);
//		Instantiate(enemies[index], CreateVector(GenerateX(), GenerateY()), Quaternion.identity);
//		#endregion fixthis
	}


	// x & y are methods GenerateX & Y
	private Vector3 CreateVector(int x, int y)
	{
		float horizontal = x * 0.1F;
		float vertical = y * 0.1F;
		return new Vector3(horizontal, vertical);
	}


	private int GenerateX()
	{
		int x = Random.Range (-36, 36);
		if (x % 2 != 0)
			x = GenerateX();
		return x;
	}


	private int GenerateY()
	{
		int y = Random.Range (-24, 24);
		if (y % 2 != 0)
			y = GenerateY();
		return y;
	}
}














