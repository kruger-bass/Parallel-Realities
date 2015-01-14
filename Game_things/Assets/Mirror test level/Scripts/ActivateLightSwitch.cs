using UnityEngine;
using System.Collections;

public class ActivateLightSwitch : MonoBehaviour {
	
	// time = 0 for permanent switch
	public float maxActivationRange = 2.0f;
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
			Debug.Log("I see you are pressing the 'e' key");
				player.BroadcastMessage("Switch");
		}
	}
}
