﻿// Copyright (C) Stanislaw Adaszewski, 2013
// http://algoholic.eu

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : MonoBehaviour {
	
	public Transform OtherEnd;
	HashSet<Collider> colliding = new HashSet<Collider>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (!colliding.Contains(other)) {
			Debug.Log ("ciao");
			//Quaternion q1 = Quaternion.FromToRotation(this.transform.position, OtherEnd.position);
			Quaternion q2 = Quaternion.FromToRotation(-transform.up, OtherEnd.up);

			//-q2 * Vector3.right to avoid spawning right inside the mirror. remove for seamless "Portal" transition
			Vector3 newPos = OtherEnd.position + q2 * (other.transform.position - transform.position) + OtherEnd.transform.up * 2;
			
			if (other.rigidbody != null) {
				GameObject o = (GameObject) GameObject.Instantiate(other.gameObject, newPos, other.transform.localRotation);
				o.rigidbody.velocity = q2 * other.rigidbody.velocity;
				o.rigidbody.angularVelocity = other.rigidbody.angularVelocity;
				other.gameObject.SetActive(false);
				Destroy(other.gameObject);
				other = o.collider;
			}

			//OtherEnd.GetComponent<Teleport>().colliding.Add(other);

			//Debug.Log (q2.ToString()+" "+newPos.ToString() + " "+ other.transform.position + " " + other.transform.forward);

			other.transform.position = newPos ;
			
			Vector3 fwd = other.transform.forward;
			
			if (other.rigidbody == null) {
				other.transform.LookAt(other.transform.position + q2 * fwd, OtherEnd.transform.forward);
			}

		}
	}
	
	void OnTriggerExit(Collider other) {
		Debug.Log ("oh");
		colliding.Remove(other);
	}
}
