// Made with help of the following tutorial:
// https://www.youtube.com/watch?v=QtKmB4ibxQA
using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	public GameObject pauseCanvas;
	private Canvas Pause;
	private bool isPaused = false;
	private float oldTimeScale ;
	private GameObject player;

	// Use this for initialization
	void Start () {
		Pause = pauseCanvas.GetComponent<Canvas> ();
		Pause.enabled = false;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !isPaused) {
			isPaused = true;
			Screen.showCursor = true;
			Screen.lockCursor = false;
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0;
			player.GetComponent<FirstPersonController> ().enabled = false;
			player.GetComponent<ToggleActiveState> ().enabled = false;
			Pause.enabled = true;
		} else if (Input.GetKeyDown (KeyCode.Escape) && isPaused)
			exitPause ();
	}

	public void exitPause(){
		isPaused = false;
		Time.timeScale = oldTimeScale;
		player.GetComponent<FirstPersonController>().enabled = true;
		player.GetComponent<ToggleActiveState>().enabled = true;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		Pause.enabled = false;
		}

	public void restartLevel(){
		exitPause ();
		Application.LoadLevel (Application.loadedLevelName);
		}

	public void quit(){
		Application.Quit();
	}
}
