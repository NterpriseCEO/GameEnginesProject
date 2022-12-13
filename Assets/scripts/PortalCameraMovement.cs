using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraMovement : MonoBehaviour {

	// Adapted from the Brackeys portal tutorial: https://www.youtube.com/watch?v=cuQao3hEKfs
	public Transform camera;
	public Transform portal;
	public Transform secondPortal;

	// Update is called once per frame
	void Update() {
		//Gets the camera offset from the portal position
		Vector3 offsetFromPortal = camera.position - secondPortal.position;
		transform.position = portal.position + offsetFromPortal;

		//Gets the angular difference between the portal and the second portal
		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, secondPortal.rotation);

		//Rotates the portal camera to make it look like the other side of the portal is in front of the player
		Quaternion rotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = rotationalDifference * camera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
