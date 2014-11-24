// Copyright (C) Stanislaw Adaszewski, 2013
// http://algoholic.eu

using UnityEngine;
using System.Collections;

public class FillScreen : MonoBehaviour {
	
	public Camera cam;
	
	public Transform portal1;
	public Camera portal1Cam;
	
	public Transform portal2;
	public Camera portal2Cam;
	
//	public Transform sky;

	// Use this for initialization
	void Start () {
		Camera.main.depthTextureMode = DepthTextureMode.Depth;
	}
	
	// Update is called once per frame. LateUpdate is called AFTER all update functions.
	void LateUpdate () {
		//sky.position = cam.transform.position;

		// quarternion is a rotation primitive
		// we use it to update the camera associated with the portals
		Quaternion q = Quaternion.FromToRotation(-portal1.up, cam.transform.forward); // First the portal1 camera
		//the camera is first placed on the other side of the portal, 
		//then moved to mimic the player's pos relative to his end of the portal
		//(but it actually ends up somewhere else... gotta check (cam.transform.position - portal1.position))
		portal1Cam.transform.position = portal2.position + (cam.transform.position - portal1.position);
		portal1Cam.transform.LookAt(portal1Cam.transform.position + q * portal2.up, portal2.transform.forward);
		portal1Cam.nearClipPlane = (portal1Cam.transform.position - portal2.position).magnitude - 0.3f;
		
		q = Quaternion.FromToRotation(-portal2.up, cam.transform.forward); // Then the portal2 camera
		portal2Cam.transform.position = portal1.position + (cam.transform.position - portal2.position);
		portal2Cam.transform.LookAt (portal2Cam.transform.position + q * portal1.up, portal1.transform.forward);
		portal2Cam.nearClipPlane = (portal2Cam.transform.position - portal1.position).magnitude - 0.3f;

		// We create a normalized square - the viewport of our camera (slightly projected forwards on z)
		Vector3[] scrPoints = new Vector3[4];
		scrPoints[0] = new Vector3(0, 0, 0.1f);
		scrPoints[1] = new Vector3(1, 0, 0.1f);
		scrPoints[2] = new Vector3(1, 1, 0.1f);
		scrPoints[3] = new Vector3(0, 1, 0.1f);

		//we turn the viewport into world coordinates, which we then turn into local coordinates to the plane that's using this script
		for (int i = 0; i < scrPoints.Length; i++) {
			scrPoints[i] = transform.worldToLocalMatrix.MultiplyPoint(cam.ViewportToWorldPoint(scrPoints[i]));
		}

		//two triangles on the local equivalent of z=0.1f, they make up the local equivalent of the viewport square
		int[] tris = new int[6] {0, 1, 2, 2, 3, 0};

		//we render the meshfilter for the plane using said triangles
		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh.Clear();
		mf.mesh.vertices = scrPoints;
		mf.mesh.triangles = tris;
		mf.mesh.RecalculateBounds();
	}
}
