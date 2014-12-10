using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class SetAspectRatio : MonoBehaviour {

	public float newAspectRatio = 1.0f;

	// Use this for initialization
	void Start () {
		camera.aspect = newAspectRatio;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
