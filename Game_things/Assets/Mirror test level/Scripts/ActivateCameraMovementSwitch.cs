using UnityEngine;
using System.Collections;

public class ActivateCameraMovementSwitch : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		foreach (GameObject potPlayer in GameObject.FindGameObjectsWithTag("Player"))
			player = potPlayer.activeInHierarchy ? potPlayer : null;
		if (player == null)
			throw new UnityException("no Player object found");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay() {
		if(Input.GetKeyDown("e")){
			Debug.Log("'e' key pressed. Moving Cameras.");
			player.BroadcastMessage("cameraMoveBegin");
		}
	}
}
