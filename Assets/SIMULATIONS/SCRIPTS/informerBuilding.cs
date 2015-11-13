using UnityEngine;
using System.Collections;

public class informerBuilding : MonoBehaviour {

	public LayerMask PlayerLayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach (Collider goCollider in Physics.OverlapSphere(gameObject.transform.position,4,PlayerLayer)) {
			GameObject obj = goCollider.gameObject;
			
			if(obj.GetComponent<Character>()){
				Inform (obj);
			}
		}

	}

	public void Inform(GameObject villager)
	{

	}
}
