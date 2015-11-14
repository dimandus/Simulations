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
	public UnityEngine.UI.Text needPrefab;
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

			Transform needs = VillagerInfo.transform.FindChild ("Needs").FindChild("Viewport").FindChild("Content");

			foreach(string need in Villager.GetComponent<Character>().needs.Keys)
			{
				if(needs.FindChild(need)!=null)//такой элемент уже есть на меню
				{
					needs.FindChild (need).GetComponent<UnityEngine.UI.Text>().text= string.Format("Нужда \"{0}\" = {1}",need,Villager.GetComponent<Character>().needs[need].ToString());
				
				}
				else//создадим новый элемент
				{
					UnityEngine.UI.Text needInfo = GameObject.Instantiate (needPrefab);
					needInfo.text = string.Format("Нужда \"{0}\" = {1}",need,Villager.GetComponent<Character>().needs[need].ToString());
					needInfo.name = need;
					needInfo.transform.SetParent(needs);
				}
			}

			foreach(Transform need in needs)//удалим ненужные нужды
			{
				if(!Villager.GetComponent<Character>().needs.ContainsKey(need.name))
				{
				GameObject.Destroy (need.gameObject);
				}
			}


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
