using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour {
	void Update() {
		//Rotates the arm 0.0007 degrees on the y axis at the end of the tonearm
		transform.Rotate(0, 0.0007f, 0);
	}
}
