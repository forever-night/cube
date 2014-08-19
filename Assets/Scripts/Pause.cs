using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
    GameObject pause;


    void Awake()
    {
        pause = GameObject.Find("lblPause");
    }

	void Update() 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;

                // show pause label
                Instantiate(pause, new Vector3(0.0F, -1.4F, 0.0F), Quaternion.identity);
            }
            else
            {
                Time.timeScale = 1;

                // stop showing pause label
                Destroy(GameObject.Find("lblPause(Clone)"));
            }
        }
    }
}
