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
		//Check for mouse click 
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit raycast;
			// get camera by name
			Camera camera = GameObject.Find("AR Camera").GetComponent<Camera>();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out raycast, 100f)) {
				if (raycast.transform != null & raycast.transform.gameObject == gameObject) {
					// Move the button forwards and backwards once using a coroutine
					coroutine = StartCoroutine(MoveButton());
				}
			}
		}
	}

	// Coroutine to move the button forwards and backwards
	IEnumerator MoveButton() {
		// Move the button forwards
		transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
		// Wait for 0.5 seconds
		yield return new WaitForSeconds(0.5f);
		//Emable or disable the tv video player
		//Get CRT game object
		GameObject crt = GameObject.Find("CRT");
		//Get video player component
		VideoPlayer videoPlayer = crt.GetComponent<VideoPlayer>();
		videoPlayer.enabled = !videoPlayer.enabled;
		// Move the button backwards
		transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);

		coroutine = null;
	}
}
