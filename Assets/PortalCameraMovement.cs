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
		Vector3 offsetFromPortal = camera.position - secondPortal.position;
		transform.position = portal.position + offsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, secondPortal.rotation);

		Quaternion rotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = rotationalDifference * camera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
