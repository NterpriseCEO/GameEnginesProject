using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVTurnOn : MonoBehaviour {
	Coroutine coroutine;

	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update() {
		//Checks for mouse clicks
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit raycast;
			// Gets the camera by name
			Camera camera = GameObject.Find("AR Camera").GetComponent<Camera>();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out raycast, 100f)) {
				if (raycast.transform != null & raycast.transform.gameObject == gameObject) {
					// Moves the button forwards and backwards once using a coroutine
					coroutine = StartCoroutine(MoveButton());
				}
			}
		}
	}

	// Coroutine to move the button forwards and backwards
	IEnumerator MoveButton() {
		// Moves the button forwards
		transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
		// Waits for 0.5 seconds
		yield return new WaitForSeconds(0.5f);
		//Emables or disable the tv video player
		//Gets CRT game object
		GameObject crt = GameObject.Find("CRT");
		//Gets video player component
		VideoPlayer videoPlayer = crt.GetComponent<VideoPlayer>();
		videoPlayer.enabled = !videoPlayer.enabled;
		// Moves the button backwards
		transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);

		coroutine = null;
	}
}
