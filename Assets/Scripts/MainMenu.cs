using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GUIStyle btnPlay;
	public GUIStyle btnQuit;
	GUIContent content = new GUIContent();


	void OnGUI()
	{
		if (GUI.Button(new Rect(220F, 140F, 280F, 80F), content, btnPlay))
		    Application.LoadLevel (1);

		if (GUI.Button (new Rect(220F, 260F, 280F, 80F), content, btnQuit))
			Application.Quit ();
	}
}
