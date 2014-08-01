using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GUISkin skin;


	void OnGUI()
	{
		GUI.skin = skin;

		// ugh i'll just leave it like this
		// nothing is working, anyway
	}
}
