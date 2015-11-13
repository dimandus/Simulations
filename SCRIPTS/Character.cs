using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

	//public string Name="Default Name Character";
	public int Health=0;
	public int Mana=0;

	public Dictionary<string,int> needs;

	private CharacterMover _mover;
	private CharacterMemory _memory;

	// Use this for initialization
	void Start () {
		_mover = gameObject.GetComponent<CharacterMover> ();
		_memory = gameObject.GetComponent<CharacterMemory> ();
		needs = new Dictionary<string, int> ();
		foreach (string need in GameLogic.villagerNeeds) {
			needs.Add (need,100);
		}

		gameObject.name = _memory.Name;
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.frameCount % 10 == 0) {
			foreach (string need in GameLogic.villagerNeeds) {
				if (needs [need] > 0) {
					needs [need]--;
				} else {
					_mover.SendChar(_memory.FindNearestBuilding (need));
				}
			}
		}

		if (_memory.StateOfCharacter == CharacterMemory.CharStates.Idle) {

			_mover.SendChar(new Vector3( _memory.Home.transform.position.x+ Random.Range (-20,20),
			                            _memory.Home.transform.position.y,
			                            _memory.Home.transform.position.z+ Random.Range (-20,20)));
		}




	}



	public void Init(string name, int maxHealth, int maxMana){
		_memory.Name = name;
		this.Health = maxHealth;
		this.Mana = maxMana;
	}



}
