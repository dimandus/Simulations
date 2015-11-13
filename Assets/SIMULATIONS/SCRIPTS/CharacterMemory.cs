using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMemory : MonoBehaviour {
	public enum CharStates {Idle, Going};
	public CharStates StateOfCharacter = CharStates.Idle;
	public LayerMask lmask;
	public GameObject Home;
	public string Name;

	public int maxBuildingsInMemory=5;
	public int visibilityRange=100;
	public List<GameObject> parents;

	public Dictionary<string, List<GameObject>> knownBuildings;


	// Use this for initialization
	void Start () {

		knownBuildings = new Dictionary<string, List<GameObject>> ();
		//Name = gameObject.name;
	}
	// Update is called once per frame
	void Update () {

	}

	public void findBuildings(){
		foreach (Collider goCollider in Physics.OverlapSphere(gameObject.transform.position,visibilityRange,lmask)) {
			GameObject house = goCollider.gameObject;
			if(house.GetComponent<producerBuilding>())
			{
				if(!knownBuildings.ContainsKey(house.GetComponent<producerBuilding>().resourse)){
					knownBuildings.Add(house.GetComponent<producerBuilding>().resourse, new List<GameObject>());
					knownBuildings[house.GetComponent<producerBuilding>().resourse].Add(house);
				}
				else
				{
					knownBuildings[house.GetComponent<producerBuilding>().resourse].Add(house);
				}
			}
		}
	}

	public Vector3 FindNearestBuilding(string need){
		float minimalDistance = int.MaxValue;
		Vector3 position = gameObject.transform.position;

		if (knownBuildings.ContainsKey (need))
		foreach (GameObject building in knownBuildings[need]) {
			if(Vector3.Distance ( gameObject.transform.position,building.transform.position)<minimalDistance)
			{
				minimalDistance = Vector3.Distance ( gameObject.transform.position,building.transform.position);
				position = building.transform.position;
			}
		}

		return position;
	}
}
