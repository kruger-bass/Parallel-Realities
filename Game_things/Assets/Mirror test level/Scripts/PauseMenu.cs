//Made with help from these tutorials: https://www.youtube.com/watch?v=QtKmB4ibxQA and https://www.youtube.com/watch?v=m4XzEaYQERY
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused = false;
	public string currentMenu;

	private int buttonWidth;
	private int buttonHeight;
	private int groupWidth;
	private int groupHeight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (Input.GetKeyDown (KeyCode.Escape) && isPaused == false) {
			currentMenu = "Main";
			isPaused = true;
			player.GetComponent<FirstPersonController> ().enabled = false; // disable movement while on menu
			player.GetComponent<ToggleActiveState>().enabled = false;
			Screen.showCursor = true;
		} else if (Input.GetKeyDown (KeyCode.Escape) && isPaused == true) {
			currentMenu = null;
			isPaused = false;
			player.GetComponent<FirstPersonController> ().enabled = true; // enable movement while on menu
			player.GetComponent<ToggleActiveState>().enabled = true;
			Screen.showCursor = true;
		}
	}

	void OnGUI(){
		if (currentMenu == "Main")
						Menu_Main ();
		if (currentMenu == "Opt")
						Menu_Opt ();

	}

	public void NavigateTo(string nextMenu){
		currentMenu = nextMenu;
	}

	public void Menu_Main(){
		GUI.BeginGroup(new Rect())
		GUI.Label(new Rect(10,10,200,50), "Paused");
		if (GUI.Button (new Rect (10, 70, 200, 50), "Options")) {
			NavigateTo("Opt");		
		}
	}

	public void Menu_Opt(){
		GUI.Label(new Rect(10,10,200,50), "Options");
		if (GUI.Button (new Rect (10, 70, 200, 50), "Back")) {
			NavigateTo ("Main");
		}
	}
}
