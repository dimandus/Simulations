using UnityEngine;
using System.Collections;

public class WindowManager 
{

	public static void Open(string windowName, Vector2 location)
	{
		GameObject window = Resources.Load ("Windows/" + windowName) as GameObject;

		GameObject newWindow = GameObject.Instantiate (window);
		newWindow.name.Remove (newWindow.name.Length - "(Clone)".Length);

	}

	public static void Open(string windowName)
	{
		Open (windowName, Vector2.zero);
	}
	

}
