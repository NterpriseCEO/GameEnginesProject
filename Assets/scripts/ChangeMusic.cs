using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {
	private Camera camera;

	// A list of all the songs
	[SerializeField] AudioClip track1;
	[SerializeField] AudioClip track2;
	[SerializeField] AudioClip gameDevAssignment;
	[SerializeField] AudioClip sweetNothings;
	[SerializeField] AudioClip futureFunk;

	// The tonearm parent game object
	GameObject armParent;

	// The audio source attached to the hi fi system
	AudioSource audioSource;

	private Song[] songs;

	// The current position in the songs array
	private int position = 0;

	// Use this for initialization
	void Start() {
		songs = new Song[] {
			new Song(track1, 0),
			new Song(track2, 2.388779395296753f),
			new Song(gameDevAssignment, 5.270481522956327f),
			new Song(sweetNothings, 10.74950727883539f),
			new Song(futureFunk, 15.41331466965286f)
		};

		// Gets the parent game objects audio source
		audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
		armParent = GameObject.Find("Arm Parent");
	}


	// Update is called once per frame
	void Update() {
		// Checks for mouse click 
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit raycast;
			// Gets camera by name
			Camera camera = GameObject.Find("AR Camera").GetComponent<Camera>();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out raycast, 100f)) {
				Debug.Log(raycast.transform.gameObject.name);
				// Checks if the raycast hit the game object
				if (raycast.transform != null & raycast.transform.gameObject == gameObject) {
					// Changes the audio clip
					position = (position + 1) % songs.Length;
					audioSource.clip = songs[position].clip;
					// Gets the Arm Parent object
					armParent.transform.localRotation = Quaternion.Euler(0, songs[position].time, 0);
					// Plays the audio clip
					audioSource.Play();
				}
			}
		}
		// check if transform parent gameobject audio is finished playing
		if(audioSource.isPlaying == false) {
			// change the audio clip
			position = (position + 1) % songs.Length;
			audioSource.clip = songs[position].clip;
			audioSource.Play();

			// Rotates the arm parent back to the start if the last song has finished playing
			if(position == 0) {
				armParent.transform.localRotation = Quaternion.Euler(0, 0, 0);
			}
		}
	}
}

class Song {
	public Song(AudioClip clip, float time) {
		this.clip = clip;
		// The time represents the rotation of the arm parent
		this.time = time;
	}

	public AudioClip clip { get; set; }
	public float time { get; set; }
}