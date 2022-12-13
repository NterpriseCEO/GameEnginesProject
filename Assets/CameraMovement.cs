using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CameraMovement : MonoBehaviour {
	
	[SerializeField] Transform camera;

	void start() {
		transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * 3, 0));
	}

	// Update is called once per frame
	void Update() {
		//Moves the camera in the direction of the mouse
		//Forwards and backwards
		if (Input.GetAxisRaw("Vertical") != 0) {
			//move camera if it is not colliding with anything

			transform.position = transform.position + camera.forward * Time.deltaTime * 2 * Input.GetAxisRaw("Vertical");
		}
		//Left and right
		if(Input.GetAxisRaw("Horizontal") != 0) {
			transform.position = transform.position + camera.right * Time.deltaTime * 2 * Input.GetAxisRaw("Horizontal");
		}

		//Rotates the camera with the mouse
		if(Input.GetAxisRaw("Mouse X") != 0) {
			transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * 3, 0));
		}
	}
}
