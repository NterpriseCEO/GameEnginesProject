using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {
	private Camera camera;

	//A list of all the songs
	[SerializeField] AudioClip track1;
	[SerializeField] AudioClip track2;
	[SerializeField] AudioClip gameDevAssignment;
	[SerializeField] AudioClip sweetNothings;
	[SerializeField] AudioClip futureFunk;

	AudioSource audioSource;

	private AudioClip[] songs;

	private int position = 0;

	// Use this for initialization
	void Start() {
		songs = new AudioClip[] { track1, track2, gameDevAssignment, sweetNothings, futureFunk };

		// Gets the parent game objects audio source
		audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update() {
		//Check for mouse click 
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit raycast;
			// get camera by name
			Camera camera = GameObject.Find("AR Camera").GetComponent<Camera>();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out raycast, 100f)) {
				Debug.Log(raycast.transform.gameObject.name);
				if (raycast.transform != null & raycast.transform.gameObject == gameObject) {
					// Get the parent game object and get the audio source
					// change the audio clip
					position = (position + 1) % songs.Length;
					audioSource.clip = songs[position];
					// play the audio clip
					audioSource.Play();
				}
			}
		}
		// check if transform parent gameobject audio is finished playing
		if(audioSource.isPlaying == false) {
			// change the audio clip
			position = (position + 1) % songs.Length;
			audioSource.clip = songs[position];
			audioSource.Play();
		}
	}
}
