using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour 
{
    public int seconds;
    public GameObject[] redEnemies;
    public GameObject[] greenEnemies;


	void Start () 
    {
	    
	}
	

	void FixedUpdate () 
    {
        // call GenerateEnemy() with time intervals = int seconds
	}


    private void GenerateEnemy()
    {
        Instantiate(
            PickEnemy(), 
            new Vector2(GenerateCoordinateX(), GenerateCoordinateY()),
            Quaternion.identity);
    }


    private GameObject PickEnemy()
    {
        GameObject enemy;
        int index;

        // randomly chooses an array, green : red = 1 : 3
        // randomly chooses enemy index
        #region enemyPicker
        int color = Random.Range(1, 4);
        if (color == 1)
        {
            index = PickEnemy(greenEnemies);
            enemy = greenEnemies[index];
        }
        else
        {
            index = PickEnemy(redEnemies);
            enemy = redEnemies[index];
        }
        #endregion enemyPicker

        return enemy;
    }


    private float GenerateCoordinateX()
    {
        float x = Random.Range(-3.6F, 3.6F);
        if (x % 0.2F != 0)
            GenerateCoordinateX();
        return x;
    }


    private float GenerateCoordinateY()
    {
        float y = Random.Range(-2.4F, 2.4F);
        if (y % 0.2F != 0)
            GenerateCoordinateY();
        return y;
    }


    // randomly chooses enemy from list
    private int PickEnemy(GameObject[] enemyArray)
    {
        int enemyNumber = Random.Range(0, enemyArray.Length);
        return enemyNumber;
    }
}














