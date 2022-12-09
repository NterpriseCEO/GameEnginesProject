using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CameraMovement : MonoBehaviour {
	
	[SerializeField] Transform camera;
	Rigidbody rb;

	float horizontalMovement;
	float verticalMovement;

	float speed = 5f;
	float rotation;

	[SerializeField] Texture2D cursor;
	Rect cursorPosition;

	Vector3 movementDirection;

	float xRotation = 0f;
	float yRotation = 0f;

	void Start() {
		transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * 3, 0));

		// Creates a rectangle for the cursor to be drawn in the center of the screen
		cursorPosition = new Rect((Screen.width - cursor.width) / 2, (Screen.height - cursor.height) /2, cursor.width, cursor.height);
		Cursor.lockState = CursorLockMode.Locked;

		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.drag = 6f;
	}

	// Update is called once per frame
	void Update() {

		horizontalMovement = Input.GetAxisRaw("Horizontal");
		verticalMovement = Input.GetAxisRaw("Vertical");

		// Sets the direction the player is moving in
		if(horizontalMovement != 0 || verticalMovement != 0) {
			movementDirection = new Vector3(transform.forward.x, 0, transform.forward.z) * verticalMovement + transform.right * horizontalMovement;
			movementDirection.Normalize();
		}
		//Rotates the camera with the mouse
		xRotation -= Mathf.Clamp(Input.GetAxisRaw("Mouse Y"), -30f, 30f);
		yRotation += Input.GetAxisRaw("Mouse X") * 3;

		//set rigidbody rotation
		rb.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

		// transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

		// transform.position = rb.position;
	}

	void FixedUpdate() {
		//move the player unless they are colliding with something
		Debug.Log(horizontalMovement + " " + verticalMovement);
		if(horizontalMovement != 0 || verticalMovement != 0) {
			rb.MovePosition(rb.position + ((movementDirection * speed * Time.fixedDeltaTime)/2));
			// rb.AddForce(movementDirection.normalized * speed, ForceMode.Acceleration);
		}
	}

	void OnGUI() {
		//Draws the cursor in the center of the screen
		GUI.DrawTexture(cursorPosition, cursor);
	}
}
