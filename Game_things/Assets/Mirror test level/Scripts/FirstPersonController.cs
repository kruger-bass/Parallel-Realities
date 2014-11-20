using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 3.0f;
	public float verticalRange = 60.0f;
	public float jumpSpeed = 1.5f;
	float verticalRotation = 0;
	float verticalVelocity = 0;
	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		float sideRotation = mouseSensitivity * Input.GetAxis ("Mouse X");
		transform.Rotate (0, sideRotation, 0);

		verticalRotation -= mouseSensitivity * Input.GetAxis ("Mouse Y");
		verticalRotation = Mathf.Clamp (verticalRotation, -verticalRange, verticalRange);
		Camera.main.transform.localRotation =  Quaternion.Euler(verticalRotation, 0, 0);

		float forwardSpeed = movementSpeed * Input.GetAxis ("Vertical");
		float sideSpeed = movementSpeed * Input.GetAxis ("Horizontal");

		verticalVelocity = Input.GetButtonDown ("Jump") && characterController.isGrounded ?
			jumpSpeed :
			verticalVelocity + Physics.gravity.y * Time.deltaTime;

		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;

		characterController.Move (speed * Time.deltaTime);
	}
}
