using UnityEngine;
using System.Collections;
using System.Linq;

public class DisableMirrors : MonoBehaviour {

	public GameObject[] mirrors;

	// Use this for initialization
	void Start () {
		//prune anything that's not a mirror
		mirrors = mirrors.Where (m => m.GetComponent<Teleport> () != null && m.GetComponent<BoxCollider>() != null).ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Switch () {
		foreach (GameObject m in mirrors)
			m.GetComponent<BoxCollider> ().isTrigger = !(m.GetComponent<BoxCollider> ().isTrigger);
	}
}
