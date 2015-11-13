using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	//public string Name="Default Name Character";
	public int Health=0;
	public int Mana=0;

	public Dictionary<string,int> needs;
	private GameObject _interface;

	private CharacterMover _mover;
	private CharacterMemory _memory;

	// Use this for initialization
	void Start () {
		_mover = gameObject.GetComponent<CharacterMover> ();
		_memory = gameObject.GetComponent<CharacterMemory> ();
		_interface = gameObject.transform.FindChild ("Canvas").gameObject;
		needs = new Dictionary<string, int> ();
		foreach (string need in GameLogic.villagerNeeds) {
			needs.Add (need,100);
		}
		gameObject.transform.FindChild ("Name").GetComponent<TextMesh> ().text = _memory.Name;
		gameObject.name = _memory.Name;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.FindChild ("Name").LookAt (Camera.main.transform.position);
		gameObject.transform.FindChild ("Name").gameObject.transform.Rotate(Vector3.up - new Vector3(0,180,0));
	if (Time.frameCount % 30 == 0) {
			foreach (string need in GameLogic.villagerNeeds) {
				if (needs [need] > 0) {
					needs [need]--;
				} 

				_interface.transform.FindChild(need).GetComponent<Image>().fillAmount = needs [need]/100f;

				if(needs [need]<25)
				{
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
