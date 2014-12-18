using UnityEngine;
using System.Collections;

public class windyScript : MonoBehaviour {
	
	public Vector3 speed;
	
	public void OnTriggerStay(Collider col) {
		CharacterController ctrl = col.gameObject.GetComponent(typeof(CharacterController)) as CharacterController;
		if (ctrl) {
			ctrl.SimpleMove(speed);
		}
	}
}