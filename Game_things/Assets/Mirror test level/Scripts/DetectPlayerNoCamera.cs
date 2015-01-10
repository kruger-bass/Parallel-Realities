using UnityEngine;
using System.Collections;

//detect player using collision with this object

public class DetectPlayerNoCamera : MonoBehaviour {

	private GameObject player;
	public Transform cameraProp;

	// Use this for initialization
	void Start () {
		foreach (GameObject potPlayer in GameObject.FindGameObjectsWithTag("Player"))
			player = potPlayer.activeInHierarchy ? potPlayer : null;
		if (player == null)
			throw new UnityException("no Player object found");
		if (cameraProp == null)
			cameraProp = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject == player)
			Detect();

	}

	void OnTriggerStay(Collider other) {

		if (other.gameObject == player) /* && (game is not over) */
			Detect();
	
	}

	void Detect() {

		// don't detect the player if anything's between him and the camera prop
		// todo: better detection (right now, even a well-placed mosquito could hide the player from our camera)
		RaycastHit info;
		// 10 is the layer SecuCamIgnore
		int layerMask = ~(1 << 10);
		if (Physics.Raycast (cameraProp.position, player.transform.position - cameraProp.position, out info, Mathf.Infinity, layerMask))
				if (info.transform.gameObject == player) {
					cameraProp.SendMessage ("Kill");
					player.SendMessage("GameOver");
				}

	}
}
