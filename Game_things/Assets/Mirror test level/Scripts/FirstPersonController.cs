﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 3.0f;
	public float verticalRange = 60.0f;
	public float jumpSpeed = 1.5f;
	public float centerHeadOffset = 1.0f;
	float verticalRotation = 0;
	float verticalVelocity = 0;
	CharacterController characterController;
	public GUIText DeadText;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		Screen.showCursor = false;
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		float sideRotation = mouseSensitivity * Input.GetAxis ("Mouse X");
		transform.Rotate (0, sideRotation, 0);
		Camera.main.transform.localRotation =  Quaternion.Euler(0, sideRotation, 0);

		verticalRotation -= mouseSensitivity * Input.GetAxis ("Mouse Y");
		verticalRotation = Mathf.Clamp (verticalRotation, -verticalRange, verticalRange);
		Camera.main.transform.localRotation =  Quaternion.Euler(verticalRotation, 0, 0);

		float forwardSpeed = movementSpeed * Input.GetAxis ("Vertical");
		float sideSpeed = movementSpeed * Input.GetAxis ("Horizontal");

		//Debug.Log (transform.position + " " + transform.up);

		RaycastHit hit;
		verticalVelocity = characterController.isGrounded ?
			Input.GetButton("Jump") ?
				jumpSpeed :
				0 :
			Physics.Raycast(transform.localPosition, transform.up, out hit, 1.1f) && !hit.transform.gameObject.CompareTag("Player") ?
				-0.1f :
				verticalVelocity + Physics.gravity.y * Time.deltaTime;
		//Debug.Log(verticalVelocity);


		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;

		characterController.Move (speed * Time.deltaTime);
	}

	void GameOver()
	{
		DeadText.text = "You have been discovered.\nThis was your last chance to escape...";
	}

	void StageOver()
	{
		DeadText.text = "Yes! We found a door.\nJust hope this take us to a exit...";
	}
}
