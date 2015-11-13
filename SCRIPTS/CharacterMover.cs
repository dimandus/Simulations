using UnityEngine;
using System.Collections;

public class CharacterMover : MonoBehaviour {

	public float Radius=100;

	//private Character _char;
	private CharacterMemory _memory;
	private NavMeshAgent navigator;

	// Use this for initialization
	void Start () {
		_memory = gameObject.GetComponent<CharacterMemory> ();
		//_char = gameObject.GetComponent<Character> ();
		navigator = gameObject.GetComponent<NavMeshAgent> ();


		GotoDestination (_memory.Home.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (navigator.destination, gameObject.transform.position) > 2) {
			gameObject.GetComponent<Animator> ().SetFloat ("Forward", navigator.speed);
		} else {
			navigator.Stop();
			navigator.ResetPath();
//			gameObject.GetComponent<Animator> ().SetFloat ("Forward", 0);
			_memory.StateOfCharacter= CharacterMemory.CharStates.Idle;
		}
	}

	public void SendChar(Vector3 dest){
		if (_memory.StateOfCharacter == CharacterMemory.CharStates.Idle) {
			GotoDestination (dest);
		}
	}

	void GotoDestination(Vector3 dest){
		if (_memory.StateOfCharacter == CharacterMemory.CharStates.Idle) {

			navigator.SetDestination (dest);
			navigator.Move (Vector3.zero);

			_memory.StateOfCharacter = CharacterMemory.CharStates.Going;
		}
		}
}
