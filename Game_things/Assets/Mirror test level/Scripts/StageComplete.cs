using UnityEngine;
using System.Collections;

public class StageComplete : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Debug.Log("player completed stage.");
			other.BroadcastMessage("StageOver");
			StartCoroutine("finishLevel");
			// Need new levels!
		}

	}

	IEnumerator finishLevel(){
		yield return new WaitForSeconds(5);
		Application.LoadLevel(1);
	}


}
