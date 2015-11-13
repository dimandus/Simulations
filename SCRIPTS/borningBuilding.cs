using UnityEngine;
using System.Collections;

public class borningBuilding : MonoBehaviour {

	public GameObject villagerExample;
	int count=0;
	private Random rnd;
	// Use this for initialization
	void Start () {
		rnd = new Random ();
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.frameCount % 100 == 0) {
			GameObject newVillager =(GameObject) GameObject.Instantiate(villagerExample,gameObject.transform.position, new Quaternion());
			//newVillager.GetComponent<Character>().Init("Villager#"+count,100,100);
			newVillager.GetComponent<CharacterMemory>().Name = "Villager#"+count;
			newVillager.GetComponent<CharacterMemory>().Home = GameLogic.buildings[Random.Range(0,GameLogic.buildings.Count)];
			//newVillager.GetComponent<CharacterMover>().SendChar(newVillager.GetComponent<CharacterMemory>().Home.transform.position);
			count++;
		}
	}
}
