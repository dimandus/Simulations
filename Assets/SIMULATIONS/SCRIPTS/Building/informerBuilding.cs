using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class informerBuilding : MonoBehaviour {

	public LayerMask PlayerLayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {

		if(other.gameObject.GetComponent<Character>()){
			Inform (other.gameObject);
		}
	}
	
	public void Inform(GameObject villager)
	{
		CharacterMemory _memory = villager.GetComponent<CharacterMemory> ();

		foreach (GameObject house in GameLogic.buildings) {
			if(house.GetComponent<producerBuilding>())
			{
				if(!_memory.knownBuildings.ContainsKey(house.GetComponent<producerBuilding>().resourse)){
					_memory.knownBuildings.Add(house.GetComponent<producerBuilding>().resourse, new List<GameObject>());
					_memory.knownBuildings[house.GetComponent<producerBuilding>().resourse].Add(house);
				}
				else
				{
					_memory.knownBuildings[house.GetComponent<producerBuilding>().resourse].Add(house);
				}
			}
		}
	}
}
