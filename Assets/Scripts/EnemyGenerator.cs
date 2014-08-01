using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour 
{
	private GameObject[] enemies;
	private int index;
    private int startFoodCount;
    private int colorChange;
    private float playerWidth;
    private float playerHeight;
    private Vector2 playerPosition;
    private Vector3 position;
    private Vector3 foodPosition;
    private GameObject player;


    void Awake()
    {
        // creates pool of enemies
        enemies = new GameObject[] {
            GameObject.Find ("1e"), GameObject.Find ("1u"), GameObject.Find ("1ui"), 
            GameObject.Find ("4e"), GameObject.Find ("4u"), GameObject.Find ("4ui"),
            GameObject.Find ("8e"), GameObject.Find ("8u"), GameObject.Find ("8ui"),
            GameObject.Find ("16e"), GameObject.Find ("16u"), GameObject.Find ("16ui"),
            GameObject.Find ("32ui")};
    }


    void Start()
    {
        player = GameObject.Find("Player");
        startFoodCount = 0;
        GetPlayerWidthHeightPosition();
        InvokeRepeating("GenerateFood", 1F, 4F);
        InvokeRepeating("GenerateEnemy", 1F, 2.5F);
        PlayerMovement.isDead = false;
    }


    void FixedUpdate()
    {
        GetPlayerWidthHeightPosition();

        if (PlayerMovement.isDead == true)
            Application.LoadLevel(0);

		if (startFoodCount == 6)
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
        foodPosition = CreateVector(GenerateX(), GenerateY(), enemies[0]);
        Instantiate(enemies[0], foodPosition, Quaternion.identity);
        startFoodCount++;
    }


    void GenerateEnemy()
    {
        index = Random.Range (0, enemies.Length);
        position = CreateVector(GenerateX(), GenerateY(), enemies[index]);
        Instantiate(enemies[index], position, Quaternion.identity);
    }


	// x & y are methods GenerateX & Y
	private Vector3 CreateVector(int x, int y, GameObject enemy)
	{
		float horizontal = x * 0.1F;
		float vertical = y * 0.1F;

        // i h8 unity
        // fuck this, it's not working properly
        // check if vector intersects player's position
        #region CheckPosition
        if (horizontal <= (playerPosition.x + playerWidth + 0.8F)
            && horizontal >= (playerPosition.x - enemy.collider2D.bounds.size.x - 0.8F)
            && vertical <= (playerPosition.y + enemy.collider2D.bounds.size.y + 0.8F)
            && vertical >= (playerPosition.y - playerHeight - 0.8F))
        {
            try{ CreateVector(x, y, enemy); }
            catch (System.StackOverflowException)
            {
                horizontal = -4F;
                vertical = 0F;
                return new Vector3(horizontal, vertical);
            }
        }
        #endregion CheckPosition

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














