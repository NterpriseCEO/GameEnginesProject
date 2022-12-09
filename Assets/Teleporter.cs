using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public Transform player;
	public Transform destination;

	private bool isPlayerOverlapping = false;

	// Update is called once per frame
	void Update() {
		//get player rigidbody
		Rigidbody rb = player.GetComponent<Rigidbody>();
		if (isPlayerOverlapping) {
			Vector3 portalToPlayer = rb.position - transform.position;

			//Checks if the player is facing the portal and if so teleports them
			// to the destination portal
			if (Vector3.Dot(transform.up, portalToPlayer) <= 0f) {
				Vector3 positionOffset = Quaternion.Euler(0f, 0f, 0f) * portalToPlayer;
				rb.position = destination.position + positionOffset;
				player.position = rb.position;
				isPlayerOverlapping = false;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Debug.Log("Player entered the portal");
			isPlayerOverlapping = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			isPlayerOverlapping = false;
		}
	}
}
