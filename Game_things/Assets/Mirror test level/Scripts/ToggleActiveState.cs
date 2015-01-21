using UnityEngine;
using System.Collections;

public class ToggleActiveState : MonoBehaviour {

	private GameObject[] togLights = null;
	private GameObject[] movCam = null;
	public float timeBeforeReset = 0;
	public GameObject generalLight;
	private bool countdown = false;

	//awake is called before ANY Start function. 
	//We'll use it so we have a list of objects BEFORE they start desactivating themselves 
	//with the StartDesactivated script.
	void Awake(){
		togLights = GameObject.FindGameObjectsWithTag("togLight");
		movCam = GameObject.FindGameObjectsWithTag ("movCam");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Switch() {
		if (countdown == false){
			countdown = true;
			//		DisableMirrors temp = null;
			foreach (GameObject l in togLights) {
				Debug.Log ("The object " + l.name + " is " + l.activeSelf);
				l.SetActive(!(l.activeSelf));
				//			if (l.GetComponent (typeof(DisableMirrors)) != null) {
				//				temp = (DisableMirrors)l.GetComponent (typeof(DisableMirrors));
				//				temp.Switch ();
				//			}
			}
			StartCoroutine("lightCD");
		}
	}

	IEnumerator lightCD() {
		yield return new WaitForSeconds(timeBeforeReset);
		for (int i = 0; i < 10; i++) {
			yield return new WaitForSeconds(0.1f);
			generalLight.light.enabled = !generalLight.light.enabled;
		}
		countdown = false;
		foreach (GameObject l in togLights) {
			Debug.Log ("The object " + l.name + " is " + l.activeSelf);
			l.SetActive(!(l.activeSelf));
		}
	}

	void cameraMoveBegin (){
		foreach (GameObject c in movCam) {
			c.BroadcastMessage("RotateCamera");
		}
		
	}

}
