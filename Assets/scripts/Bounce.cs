using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	[SerializeField] float bounceRate = 0.001f;

	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update() {
		//Bounces gameobjects up and down to make them look like they are floating
		transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time) * bounceRate, transform.position.z);
	}
}
