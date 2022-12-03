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

	Vector3 movementDirection;

	void Start() {
		transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * 3, 0));

		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.drag = 6f;
	}

	// Update is called once per frame
	void Update() {

		horizontalMovement = Input.GetAxisRaw("Horizontal");
		verticalMovement = Input.GetAxisRaw("Vertical");

		movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

		// Debug.Log(movementDirection);

		//Moves the camera in the direction of the mouse
		//Forwards and backwards
		// if (Input.GetAxisRaw("Vertical") != 0) {
		// 	//move camera if it is not colliding with anything

		// 	transform.position = transform.position + camera.forward * Time.deltaTime * 2 * Input.GetAxisRaw("Vertical");
		// }
		// //Left and right
		// if(Input.GetAxisRaw("Horizontal") != 0) {
		// 	transform.position = transform.position + camera.right * Time.deltaTime * 2 * Input.GetAxisRaw("Horizontal");
		// }

		//Rotates the camera with the mouse
		if(Input.GetAxisRaw("Mouse X") != 0) {
			transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * 3, 0));
		}

		// rotation = Input.GetAxisRaw("Mouse X") * 3 * 0.1f;

		// rotation = Mathf.Clamp(rotation, -90f, 90f)

		// camera.transform.localRotation = Quaternion.Euler(rotation, 0, 0);
		// transform.rotation = Quaternion.Euler(0, 0, 0);

		transform.position = rb.position;
	}

	void FixedUpdate() {
		//move the player unless they are colliding with something
		rb.MovePosition(rb.position + ((movementDirection * speed * Time.fixedDeltaTime)/2));
		// rb.AddForce(movementDirection.normalized * speed, ForceMode.Acceleration);
	}
}
