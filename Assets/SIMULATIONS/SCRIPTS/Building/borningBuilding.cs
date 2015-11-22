using UnityEngine;
using System.Collections;

public class borningBuilding : MonoBehaviour {

	public GameObject villagerExample;
	int count;
	private Random rnd;
	// Use this for initialization
	void Start () {
		rnd = new Random ();
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	if ((Time.frameCount % 100 == 0) && GameLogic.villagers.Count<20) {
			GameObject newVillager =(GameObject) GameObject.Instantiate(villagerExample,gameObject.transform.position, new Quaternion());
			newVillager.GetComponent<CharacterMemory>().Name = "Villager#"+count;
			newVillager.GetComponent<CharacterMemory>().Home = GameLogic.buildings[Random.Range(0,GameLogic.buildings.Count)];
			GameLogic.villagers.Add(newVillager);
			count++;
		}
	}
}
