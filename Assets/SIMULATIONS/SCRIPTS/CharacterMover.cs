using UnityEngine;
using System.Collections;

public class CharacterMover : MonoBehaviour
{

	public float Radius = 100;
	private CharacterMemory _memory;
	private NavMeshAgent navigator;

	// Use this for initialization
	void Start ()
	{
		_memory = gameObject.GetComponent<CharacterMemory> ();
		navigator = gameObject.GetComponent<NavMeshAgent> ();
		SendChar (_memory.Home.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (navigator.path.status == NavMeshPathStatus.PathComplete && navigator.remainingDistance < navigator.stoppingDistance) {
			navigator.Stop ();
			navigator.ResetPath ();
			_memory.StateOfCharacter = CharacterMemory.CharStates.Idle;
			gameObject.GetComponent<Animator> ().SetFloat ("Forward", 0);
		} else {

		}
	}

	public void SendChar (Vector3 dest)
	{
		if (_memory.StateOfCharacter == CharacterMemory.CharStates.Idle) {
			navigator.SetDestination (dest);
			gameObject.GetComponent<Animator> ().SetFloat ("Forward", 2);
			_memory.StateOfCharacter = CharacterMemory.CharStates.Going;
			
		}
	}
}
