using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public GameObject normalCanvas;
	public GameObject creditCanvas;
	private Canvas Credit;
	private Canvas MainMenuCanvas;
	// Use this for initialization
	void Awake () {
		MainMenuCanvas = normalCanvas.GetComponent<Canvas> ();
		Credit = creditCanvas.GetComponent<Canvas> ();
	}

	void Start()
	{	
		Screen.showCursor = enabled; // MAKING SURE CURSOR IS VISIBLE
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickGameStart ()
	{
		Application.LoadLevel (2); // load Prototype level
	}

	public void OnClickQuit (){
		Application.Quit (); // ends application
	}

	public void OnClickCredits(){
		MainMenuCanvas.enabled = false;
		Credit.enabled = true;
	}

	public void OnClickBack(){
		MainMenuCanvas.enabled = true;
		Credit.enabled = false;
	}

}
