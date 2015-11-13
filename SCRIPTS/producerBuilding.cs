using UnityEngine;
using System.Collections;

public class producerBuilding : MonoBehaviour {

	public string resourse="Some";
	public LayerMask PlayerLayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Collider goCollider in Physics.OverlapSphere(gameObject.transform.position,4,PlayerLayer)) {
			GameObject obj = goCollider.gameObject;

			if(obj.GetComponent<Character>()){
				obj.GetComponent<Character>().needs[resourse]=100;
				obj.GetComponent<CharacterMemory>().findBuildings();
			}
		}
	
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere (gameObject.transform.position, 4);
	}


}
