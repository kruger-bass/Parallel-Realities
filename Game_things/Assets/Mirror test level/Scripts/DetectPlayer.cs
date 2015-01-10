using UnityEngine;
using System.Collections;

//detect player using a camera object

[RequireComponent(typeof(Camera))]
public class DetectPlayer : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		foreach (GameObject potPlayer in GameObject.FindGameObjectsWithTag("Player"))
			player = potPlayer.activeInHierarchy ? potPlayer : null;
		if (player == null)
			throw new UnityException("no Player object found");
	}
	
	// Update is called once per frame
	void Update () {
		// check if player is in sight
		// should probably sendMessage to ad hoc object controlling game state
		if (GeometryUtility.TestPlanesAABB (GeometryUtility.CalculateFrustumPlanes (camera),
			                               player.collider.bounds)) {
			// we can't see through walls!
			RaycastHit info;
			if (Physics.Raycast (transform.position, player.transform.position - transform.position, out info) && info.collider.tag.Equals ("Player"))
			{
				transform.parent.SendMessage ("Kill");
				info.transform.parent.SendMessage("GameOver");
			}
		}

	}
}
