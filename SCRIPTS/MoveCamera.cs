using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public int speedMoving=10;
	public int speedScrolling=300;
	public int minScroll=11;
	public int maxScroll=50;
	public int maxAngle=80;
	public int minAngle=30;

	private int currentScrolling;
	public float currentAngle;

	// Use this for initialization
	void Start () {
		currentScrolling = (maxScroll + minScroll) / 2-10;
		currentAngle = Camera.main.transform.localEulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (2)) {
			Rotating ();
		} else {
			Moving ();
		}
	}




		private void Rotating(){

		RaycastHit hit = new RaycastHit ();
		Ray camRay = new Ray (transform.position, transform.FindChild ("Main Camera").transform.forward);
		Physics.Raycast (Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2)).origin,
		                 Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2)).direction, out hit, 100, Physics.DefaultRaycastLayers);
		if (Mathf.Abs (Input.GetAxis ("Mouse X")) > 0) {
			//Camera.main.transform.RotateAround (hit.point,Vector3.up,Input.GetAxis("Mouse X")*10);
			transform.RotateAround (hit.point, Vector3.up, Input.GetAxis ("Mouse X") * 10);
		} else {
			if (Mathf.Abs (Input.GetAxis ("Mouse Y")) > 0) {
				//transform.RotateAround (hit.point, Vector3.right, Input.GetAxis ("Mouse Y") * 10);
			}
		}
		
		return;

		}
	
		private void Moving(){
			int currentSpeedMoving = speedMoving* (int)transform.position.y/10;
			if (transform.position.x>0 && (int)Input.mousePosition.x < 5) {
				transform.position-=transform.right*Time.deltaTime*currentSpeedMoving;
				
			}
			if (transform.position.x<=500 && (int)Input.mousePosition.x > Screen.width-5) {
				transform.position+=transform.right*Time.deltaTime*currentSpeedMoving;
				
			}
			if (transform.position.z>0 &&(int)Input.mousePosition.y < 5) {
				transform.position-=transform.forward*Time.deltaTime*currentSpeedMoving;
			}
			if (transform.position.z< 400 &&(int)Input.mousePosition.y > Screen.height - 5) {
				transform.position+=transform.forward*Time.deltaTime*currentSpeedMoving;
			}
			
		if (Input.GetAxis("Mouse ScrollWheel")>0 && gameObject.transform.position.y>minScroll) {
			//transform.position+= Quaternion.Euler (Camera.main.transform.rotation.eulerAngles)*  transform.forward*Time.deltaTime*speedScrolling;
			gameObject.transform.position+= Camera.main.transform.forward*Time.deltaTime*speedScrolling;
				currentScrolling--;
			}
		if (gameObject.transform.position.y < minScroll) {
			gameObject.transform.position = new Vector3(gameObject.transform.position.x,minScroll,gameObject.transform.position.z);
		}
			
		if (Input.GetAxis("Mouse ScrollWheel")<0 && gameObject.transform.position.y<maxScroll) {
			//transform.position-= Quaternion.Euler (Camera.main.transform.rotation.eulerAngles)*  transform.forward*Time.deltaTime*speedScrolling;
			gameObject.transform.position-= Camera.main.transform.forward*Time.deltaTime*speedScrolling;
				currentScrolling++;
			}
	}

}
