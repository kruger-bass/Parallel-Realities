using UnityEngine;
using System.Collections;

public class ToggleActiveState : MonoBehaviour {

	private GameObject[] lights = null;
	public float timeBeforeReset = 0;
	private bool countdown = false;

	//awake is called before ANY Start function. 
	//We'll use it so we have a list of objects BEFORE they start desactivating themselves 
	//with the StartDesactivated script.
	void Awake(){
		lights = GameObject.FindGameObjectsWithTag("Light");
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
			foreach (GameObject l in lights) {
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
		countdown = false;
		foreach (GameObject l in lights) {
			Debug.Log ("The object " + l.name + " is " + l.activeSelf);
			l.SetActive(!(l.activeSelf));
		}
	}
}
