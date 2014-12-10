/* This script draws a camera frustum that appropriately handles custom Aspect Ratios.
 * It draws as 4X3 aspect ratio if no game window is visible
 * taken from PushyPixels channel on Youtube */
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class DrawAccurateFrustum : MonoBehaviour
{
	void OnDrawGizmosSelected()
	{
		// Top left
		Vector3 tlN = camera.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, camera.nearClipPlane));
		Vector3 tlF = camera.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, camera.farClipPlane));
		
		// Top right
		Vector3 trN = camera.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, camera.nearClipPlane));
		Vector3 trF = camera.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, camera.farClipPlane));
		
		// Bottom left
		Vector3 blN = camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, camera.nearClipPlane));
		Vector3 blF = camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, camera.farClipPlane));
		
		// Bottom right
		Vector3 brN = camera.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, camera.nearClipPlane));
		Vector3 brF = camera.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, camera.farClipPlane));
		
		Gizmos.color = Color.white;
		
		// Near
		Gizmos.DrawLine(tlN, trN);
		Gizmos.DrawLine(trN, brN);
		Gizmos.DrawLine(brN, blN);
		Gizmos.DrawLine(blN, tlN);
		
		// Far
		Gizmos.DrawLine(tlF, trF);
		Gizmos.DrawLine(trF, brF);
		Gizmos.DrawLine(brF, blF);
		Gizmos.DrawLine(blF, tlF);
		
		// Sides
		Gizmos.DrawLine(tlN, tlF);
		Gizmos.DrawLine(trN, trF);
		Gizmos.DrawLine(brN, brF);
		Gizmos.DrawLine(blN, blF);
	}
}