//Rotation parts based on cadenburleson rotation script
//Available for free on www.cadenburleson.com/2013/06/09/free-rotating-object-script-for-unity3d-in-c/
using UnityEngine;
using System.Collections;

public class CamBehavior : MonoBehaviour {

	public float rotationSpeed = 2.0f;
	public float rotationHalfAngle = 30.0f;
	private bool gameOver = false;
	public float myRotationSpeed = 100.0f;
	public int maxRotation = 100;
	private bool isRotating = false;

	// CHANGE TO ROTATE IN OPPOSITE DIRECTION
	public bool positiveRotation = false;
	
	private int posOrNeg = 1;

	// Use this for initialization
	void Start ()
	{
		collider.isTrigger = true;
		if(positiveRotation == false)
		{
			posOrNeg = -1;
		}
	}

	// (likely) not framerate independent
	IEnumerator Rotate() {
		float currentAngle = 0;
		float newAngle = 0;
		while (!gameOver) {
			newAngle = Mathf.SmoothStep(-rotationHalfAngle, rotationHalfAngle, Mathf.PingPong(Time.time/(20 / rotationSpeed), 1));
			transform.Rotate(Vector3.up, newAngle - currentAngle);
			currentAngle = newAngle;
			yield return null;
		}
	}

	void Kill() {
		Debug.Log ("you should be dead now kiddo");
		StartCoroutine(WaitAndReset());
	}

	IEnumerator WaitAndReset() {
		yield return new WaitForSeconds(3);
		Application.LoadLevel (Application.loadedLevel);
	}
	
	// Update is called once per frame
	IEnumerator RotateCamera ()
	{
		if (isRotating == false) { 	// THIS IS A SHARED VARIABLE RACE CONDITION. NO IDEA HOW TO SOLVE IT ON UNITY
			isRotating = true;		// LETS HOPE THE PLAYERS CANT ACTIVATE THIS FUNCTION FAST ENOUGH!
			for (int i = 0; i < maxRotation; i++) {
				transform.Rotate (0, myRotationSpeed * Time.deltaTime * posOrNeg, 0, Space.World);//rotates coin on global Y axis
				yield return new WaitForFixedUpdate ();
			}
			posOrNeg *= -1;
			isRotating = false;
		}
	}
}
