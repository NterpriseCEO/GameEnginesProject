using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour {
	AudioSource audioSource;
	GameObject light;

	// Start is called before the first frame update
	void Start() {
		audioSource = transform.parent.transform.parent.gameObject.GetComponent<AudioSource>();
		//Finds game object called light in the scene
		light = GameObject.Find("Light");
	}

	// Update is called once per frame
	void Update() {
		// Checks for mouse click 
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit raycast;
			// Gets the primary camera by name
			Camera camera = GameObject.Find("AR Camera").GetComponent<Camera>();
			// Casts a ray from the camera to the mouse position
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out raycast, 100f)) {
				if (raycast.transform != null & raycast.transform.gameObject == gameObject) {
					// (Un)mutes the audio source
					audioSource.mute = !audioSource.mute;
					// Rotates the on/off switch 20/-20 degrees on the y axis based on the current mute state
					transform.Rotate(0, audioSource.mute ? 20 : -20, 0);
					// Sets the status light's material colour to red / green based on the current mute state
					light.GetComponent<Renderer>().material.color = audioSource.mute ? Color.red : Color.green;
				}
			}
		}
	}
}
