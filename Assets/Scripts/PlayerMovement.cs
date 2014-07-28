using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private static float rightEdge = 3.6f;
    private static float leftEdge = -1f * rightEdge;
    private static float topEdge = 2.4f;
    private static float bottomEdge = -1f * topEdge;
    
    private float unit = 0.2f;
    private float width;
    private float height;
    private Vector2 spawn;
    private Vector2 nextPosition;
    
    public PolygonCollider2D[] colliders;
    public SpriteRenderer[] sprites;
    
    
    void Start () 
    {
        spawn = gameObject.transform.position;
		PointSystem.level = 0;
		PointSystem.points = 0;	
		ChangePlayer(0);
    }
    

    void FixedUpdate () 
    {
        Movement();
        ChangePlayer(PointSystem.level);
    }


    private void Movement()
    {
        nextPosition = rigidbody2D.position;

        nextPosition.y += unit * Input.GetAxisRaw ("Vertical");         
        nextPosition.x += unit * Input.GetAxisRaw ("Horizontal");

        // prevents player from going beyond edges of the screen
		#region ScreenBounds
        nextPosition.x = nextPosition.x < leftEdge ? leftEdge : nextPosition.x;
        nextPosition.x = nextPosition.x > (rightEdge - width) ?
            (rightEdge - width) : nextPosition.x;
        nextPosition.y = nextPosition.y > topEdge ? topEdge : nextPosition.y;
        nextPosition.y = nextPosition.y < (bottomEdge + height) ? 
            (bottomEdge + height) : nextPosition.y;
		#endregion ScreenBounds

        rigidbody2D.MovePosition (nextPosition);
        Input.ResetInputAxes ();
    }


    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "red")
        {
            gameObject.transform.position = spawn;
			Start();
        }
    }


    private void OnTriggerEnter2D(Collider2D food)
    {
        if (food.gameObject.tag == "green")
        {
            EnemyMovement enemy = (EnemyMovement)food.gameObject.GetComponent (typeof(EnemyMovement));

            // ensure enemy is not null
            try
            {
                PointSystem.AddPoints (enemy);
            }
            catch
            {
                print("couldn't access script, " +
                    "didn't receive EnemyMovement component");
            }
            Destroy(food.gameObject);
        }
    }
    
    
	// changes sprite, collider and sets height and width
    private void ChangePlayer(int level)
	{
		for (int i = 0; i < 5; i++)
		{
			colliders[i].enabled = false;
			if (level == i)
			{
				colliders[level].enabled = true;
				GetComponent<SpriteRenderer>().sprite = sprites[level].sprite;
				SetObjectBounds(level);
			}
		}
	}


	// gets width and height from colliders in array
	// collider should be enabled for method to work properly
	private void SetObjectBounds(int index)
	{
		width = colliders[index].bounds.size.x;
		height = colliders[index].bounds.size.y;
	}
}













