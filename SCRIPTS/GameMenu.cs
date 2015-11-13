using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	public GUISkin mainUI;
	public int numDepth=0;
	public string nameWindow;

	public RenderTexture map;
	public Material mat;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log("Quit");
			Application.Quit ();
		}

	}

	void OnGUI(){
		GUI.depth = numDepth;
		GUI.skin = mainUI;


//			if (Event.current.type.Equals (EventType.Repaint)) {
//				Graphics.DrawTexture (new Rect(0,Screen.height-128,128,128), map,mat);
//			}
	}
}
