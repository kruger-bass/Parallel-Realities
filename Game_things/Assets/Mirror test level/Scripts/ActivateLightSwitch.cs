using UnityEngine;
using System.Collections;

public class ActivateLightSwitch : MonoBehaviour {

	private GameObject[] lights = null;
	// time = 0 for permanent switch
	public float timeBeforeReset = 0;
	public float maxActivationRange = 2.0f;
	private bool countdown = false;
	private GameObject player;

	//awake is called before ANY Start function. 
	//We'll use it so we have a list of objects BEFORE they start desactivating themselves 
	//with the StartDesactivated script.
	void Awake(){
		lights = GameObject.FindGameObjectsWithTag("Light");
	}


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

	void Switch() {
//		DisableMirrors temp = null;
		foreach (GameObject l in lights) {
			Debug.Log ("The object " + l.name + " is " + l.activeSelf);
			l.SetActive(!(l.activeSelf));
//			if (l.GetComponent (typeof(DisableMirrors)) != null) {
//				temp = (DisableMirrors)l.GetComponent (typeof(DisableMirrors));
//				temp.Switch ();
//			}
		}
		if (countdown)
			countdown = false;
		else if (timeBeforeReset != 0) {
			countdown = true;
			Invoke ("Switch", timeBeforeReset);
		}
	}

	void OnTriggerStay() {
		if(Input.GetKeyDown("e")){
			Debug.Log("I see you are pressing the left mouse button");
			// only activate if in range, switch isn't obstructed and isn't activated (ie. timed activity)
			if (!countdown && (transform.position - player.transform.position).sqrMagnitude <= (maxActivationRange * maxActivationRange)) {
				RaycastHit info;
				if (Physics.Raycast (transform.position, player.transform.position - transform.position, out info)
				    	&& info.collider.tag.Equals ("Player"))
					Switch();
			}
		}
	} 
}
