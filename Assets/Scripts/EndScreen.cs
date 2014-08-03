using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour 
{
	public GUIStyle lblScore;
	public GUIStyle lblRestart;
	public GUIStyle btnYes;
	public GUIStyle btnNo;
	public GUIStyle score;
	GUIContent content = new GUIContent();


	void OnGUI()
	{
		GUI.Label (new Rect(140F, 120F, 280F, 80F), content, lblScore);
		GUI.Label (new Rect(220F, 240F, 280F, 80F), content, lblRestart);
		GUI.Label (new Rect(400F, 140F, 280F, 80F), PointSystem.points.ToString (), score);

		if(GUI.Button (new Rect(140F, 340F, 140F, 80F), content, btnYes))
			Application.LoadLevel (1);

		// go to main menu
		if(GUI.Button (new Rect(440F, 340F, 140F, 80F), content, btnNo))
			Application.LoadLevel (0);
	}
}
