using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRecord : MonoBehaviour {

	// Update is called once per frame
	void Update() {
		//Rotates the record to make it look like it's playing the music
		transform.Rotate(0, 15, 0);
	}
}
