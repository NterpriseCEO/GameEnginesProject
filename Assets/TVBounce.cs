using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVBounce : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update() {
		//Bounce the tv up and down
		transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time) * 0.01f, transform.position.z);
	}
}
