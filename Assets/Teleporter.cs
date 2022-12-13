using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public Transform player;
	public Transform destination;

	private bool isPlayerOverlapping = false;

	// Update is called once per frame
	void Update() {
		if (isPlayerOverlapping) {
			Vector3 portalToPlayer = player.position - transform.position;

			//Checks if the player is facing the portal and if so teleports them
			if (Vector3.Dot(transform.up, portalToPlayer) == 0f) {
				Vector3 positionOffset = Quaternion.Euler(0f, 0f, 0f) * portalToPlayer;
				player.position = destination.position + positionOffset;

				isPlayerOverlapping = false;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			isPlayerOverlapping = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			isPlayerOverlapping = false;
		}
	}
}
