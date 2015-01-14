using UnityEngine;
using System.Collections;

public class StageComplete : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Debug.Log("player completed stage.");
			other.BroadcastMessage("StageOver");
			// Need new levels!
	//		Application.LoadLevel();
		}

	}


}
