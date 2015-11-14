using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	public GUISkin mainUI;
	public int numDepth=0;
	public string nameWindow;

	public RenderTexture map;
	public Material mat;
	public GameObject villagersListText;
	public Canvas VillagerInfo;

	private GameObject Villager;

	// Use this for initialization
	void Start () {
		VillagerInfo.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		//ScrollView.GetComponent<GUI.
		string villagerList = "";

		foreach (GameObject villager in GameLogic.villagers) {
			villagerList+= string.Format("{0}, F={1}, W={2}\r\n",villager.GetComponent<CharacterMemory>().Name,
			                             villager.GetComponent<Character>().needs["Food"].ToString(),
			                             villager.GetComponent<Character>().needs["Water"].ToString());
		}

		villagersListText.GetComponent<UnityEngine.UI.Text> ().text = villagerList;
	if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log("Quit");
			Application.Quit ();
		}

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();


			if(Physics.Raycast (ray,out hit) && hit.collider.gameObject.tag=="Villager")
			{
				Villager = hit.collider.gameObject;
				ShowVillagerInfo ();
			}
		}

		UpdateVillagerInfo ();

	}

	public void CloseVillagerInfo()
	{
		if(Villager!=null)
		{
			Villager.transform.FindChild ("Camera").GetComponent<Camera> ().enabled = false;
			VillagerInfo.enabled=false;
			Villager=null;
		}
	}
	public void ShowVillagerInfo()
	{
//		CharacterMemory villagerMemory = Villager.GetComponent<CharacterMemory> ();
//		VillagerInfo.transform.FindChild ("Name").FindChild ("Value").GetComponent<UnityEngine.UI.Text> ().text = villagerMemory.Name;
//		VillagerInfo.transform.FindChild ("Home").FindChild ("Value").GetComponent<UnityEngine.UI.Text> ().text = villagerMemory.Home;
//		VillagerInfo.transform.FindChild ("Status").FindChild ("Value").GetComponent<UnityEngine.UI.Text> ().text = villagerMemory.StateOfCharacter.ToString();
		Villager.transform.FindChild ("Camera").GetComponent<Camera> ().enabled = true;
		VillagerInfo.enabled=true;

	}

	public void UpdateVillagerInfo()
	{
		if (VillagerInfo.enabled) {
			CharacterMemory villagerMemory = Villager.GetComponent<CharacterMemory> ();
			VillagerInfo.transform.FindChild ("Name").FindChild ("Value").GetComponent<UnityEngine.UI.Text> ().text = villagerMemory.Name;
			VillagerInfo.transform.FindChild ("Home").FindChild ("Value").GetComponent<UnityEngine.UI.Text> ().text = villagerMemory.Home.name;
			VillagerInfo.transform.FindChild ("Age").FindChild ("Value").GetComponent<UnityEngine.UI.Text> ().text = villagerMemory.Age.ToString();
			VillagerInfo.transform.FindChild ("Status").FindChild ("Value").GetComponent<UnityEngine.UI.Text> ().text = villagerMemory.StateOfCharacter.ToString();
		}
	}

	void OnGUI(){
		GUI.depth = numDepth;
		GUI.skin = mainUI;


//			if (Event.current.type.Equals (EventType.Repaint)) {
//				Graphics.DrawTexture (new Rect(0,Screen.height-128,128,128), map,mat);
//			}
	}
}
