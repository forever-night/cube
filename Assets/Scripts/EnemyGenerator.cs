using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour 
{
	private int index, startFoodCount, colorChange;
    private float playerWidth, playerHeight;
    private Vector2 playerPosition;
    private Vector3 position, foodPosition;
    private GameObject player;
    private GameObject[] greenEnemies;
    private GameObject[] redEnemies;


    void Awake()
    {
        // creates pool of enemies
		// e = green, u = red, ui = red, doesn't change color					
        redEnemies = new GameObject[] {
            GameObject.Find ("1u"), GameObject.Find ("1ui"), 
            GameObject.Find ("4u"), GameObject.Find ("4ui"),
            GameObject.Find ("8u"), GameObject.Find ("8ui"),
            GameObject.Find ("16u"), GameObject.Find ("16ui"),
            GameObject.Find ("32ui")};

        greenEnemies = new GameObject[] {
            GameObject.Find ("1e"), GameObject.Find ("4e"), 
            GameObject.Find ("8e"), GameObject.Find ("16e")};
    }


    void Start()
    {
        player = GameObject.Find("Player");
        startFoodCount = 0;
        GetPlayerWidthHeightPosition();
        InvokeRepeating("GenerateFood", 1F, 2.5F);
        InvokeRepeating("GenerateRedEnemy", 1F, 2.5F);
        InvokeRepeating("GenerateGreenEnemy", 2F, 3F);
    }


    void FixedUpdate()
    {
        GetPlayerWidthHeightPosition();

		if (startFoodCount == 8)
			CancelInvoke("GenerateFood");
    }


    private void GetPlayerWidthHeightPosition()
    {
        PlayerMovement pm = (PlayerMovement)player.GetComponent(typeof(PlayerMovement));
        playerWidth = pm.width;
        playerHeight = pm.height;
        playerPosition = pm.rigidbody2D.position;
    }

    // generates green enemies of size 1
    void GenerateFood()
    {
        foodPosition = CreateVector(greenEnemies[0]);
        Instantiate(greenEnemies[0], foodPosition, Quaternion.identity);
        startFoodCount++;
    }


    void GenerateRedEnemy()
    {
        index = Random.Range (0, redEnemies.Length);
        position = CreateVector(redEnemies[index]);
        Instantiate(redEnemies[index], position, Quaternion.identity);
    }


    void GenerateGreenEnemy()
    {
        index = Random.Range(0, greenEnemies.Length);
        position = CreateVector(greenEnemies[index]);
        Instantiate(greenEnemies[index], position, Quaternion.identity);
    }


	// enemy is needed to get collider size
	private Vector3 CreateVector(GameObject enemy)
	{
		float x = GenerateX(enemy);
		float y = GenerateY(enemy);

		// check if enemy intersects the player
        #region CheckPosition

		if (y < playerPosition.y + enemy.collider2D.bounds.size.y + 0.4F
		    && y > playerPosition.y - playerHeight - 0.4F)
		{
			if (x == playerPosition.x + playerWidth)
				x += 0.6F;
			else if (x >= playerPosition.x && x <= playerPosition.x + playerWidth)
				x += 1.4F;
			else if (playerPosition.x == x + enemy.collider2D.bounds.size.x)
				x -= 0.6F;
			else if (x > playerPosition.x - enemy.collider2D.bounds.size.x
			         && x < playerPosition.x)
				x = x - enemy.collider2D.bounds.size.x - 0.6F;
			else
				x = x;
		}
		
		if (x < playerPosition.x - 0.4F
		    && x > playerPosition.x + playerWidth + 0.4F)
		{
			if (y == playerPosition.y - playerHeight)
				y -= 0.6F;
			else if (y <= playerPosition.y && y > playerPosition.y - playerHeight)
				y = y - playerPosition.y - 0.4F;
			else if (y - enemy.collider2D.bounds.size.y > playerPosition.y - playerHeight
			         && y + enemy.collider2D.bounds.size.y < y + 0.4F)
				y += 0.6F;
			else if (y == playerPosition.y + enemy.collider2D.bounds.size.y)
				y += 0.6F;
			else
				y = y;
		}

		#endregion CheckPosition

		print("final " + x + ", " + y);

		return new Vector3(x, y);
	}


	private float GenerateX(GameObject enemy)
	{
		int horizontal = Random.Range (-36, 36);
		if (horizontal % 2 != 0)
			horizontal--;
		float x = horizontal * 0.1F;
		return x;
	}


	private float GenerateY(GameObject enemy)
	{
		int vertical = Random.Range (-24, 24);
		if (vertical % 2 != 0)
			vertical--;
		float y = vertical * 0.1F;
		return y;
	}
}