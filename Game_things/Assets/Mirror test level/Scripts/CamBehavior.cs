using UnityEngine;
using System.Collections;

public class CamBehavior : MonoBehaviour {

	public float rotationSpeed = 2.0f;
	public float rotationHalfAngle = 30.0f;
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
		//transform.Rotate(Vector3.up, rotationAngle);
		if (rotationSpeed == 0)
			rotationSpeed = 1.0f;
		StartCoroutine (Rotate());
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
		gameOver = true;
		Debug.Log ("you should be dead now kiddo");
	}

	// Update is called once per frame
	void Update () {

	}
}
