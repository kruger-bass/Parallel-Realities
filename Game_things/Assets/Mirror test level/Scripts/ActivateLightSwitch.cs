using UnityEngine;
using System.Collections;

public class ActivateLightSwitch : MonoBehaviour {

	public Light[] lights;
	// time = 0 for permanent switch
	public float timeBeforeReset = 0;
	public float maxActivationRange = 2.0f;
	private bool countdown = false;
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

	void Switch() {
		DisableMirrors temp = null;
		foreach (Light l in lights) {
			l.enabled = !l.enabled;
			if (l.GetComponent (typeof(DisableMirrors)) != null) {
				temp = (DisableMirrors)l.GetComponent (typeof(DisableMirrors));
				temp.Switch ();
			}
		}
		if (countdown)
			countdown = false;
		else if (timeBeforeReset != 0) {
			countdown = true;
			Invoke ("Switch", timeBeforeReset);
		}
	}

	void OnMouseDown() {
		// only activate if in range, switch isn't obstructed and isn't activated (ie. timed activity)
		if (!countdown && (transform.position - player.transform.position).sqrMagnitude <= (maxActivationRange * maxActivationRange)) {
			RaycastHit info;
			if (Physics.Raycast (transform.position, player.transform.position - transform.position, out info)
			    	&& info.collider.tag.Equals ("Player"))
				Switch();
		}
	} 
}
