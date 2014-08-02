using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GUIStyle btnPlay;
	public GUIStyle btnQuit;

	void OnGUI()
	{
		if (GUI.Button(new Rect(220F, 140F, 280*0.2F, 80*0.2F), "", btnPlay))
		    Application.LoadLevel (0);

		if (GUI.Button (new Rect(220F, 240F, 280*0.2F, 80*0.2F), "", btnQuit))
			Application.Quit ();
	}
}
