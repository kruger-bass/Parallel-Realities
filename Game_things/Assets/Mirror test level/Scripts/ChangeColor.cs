using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ChangeColor : MonoBehaviour {

	MeshRenderer render;
	GameObject brother;
	public Material black;
	public Material white;
	public bool startWhite = true;

	// Use this for initialization
	void Start () {
		render = GetComponent<MeshRenderer> ();
		brother = transform.parent.Find ("Plane").gameObject as GameObject;
		Switch (startWhite);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("q")) {
			if (renderer.sharedMaterial.Equals (black))
				Switch (true);
			else
				Switch (false);
		}
	}

	void Switch (bool toWhite) {
		renderer.material = toWhite ? white : black;
		brother.SetActive (toWhite);
	}
}
