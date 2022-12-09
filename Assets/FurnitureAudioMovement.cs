using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureAudioMovement : MonoBehaviour {
	
	[SerializeField] AudioSource audioSource;
	AudioClip clip;
	float[] samples;

	float lerpedAverage = 0f;

	int frameSize = 512;

	[SerializeField] float scaleX = 1f;
	[SerializeField] float scaleY = 1f;

	// Start is called before the first frame update
	void Start() {
		clip = audioSource.clip;

		samples = new float[frameSize];
	}

	// Update is called once per frame
	void Update() {
		audioSource.GetOutputData(samples, 0);
		float sum = 0f;
		for (int i=0; i < frameSize; i++){
			sum += samples[i]*samples[i]; // sum squared samples
		}
		// The size of the object is based on the average of the samples
		float average = sum / frameSize;
		lerpedAverage = Mathf.Lerp(lerpedAverage, average, Time.deltaTime * 4);
		//move furniture
		transform.localScale = (new Vector3(lerpedAverage, lerpedAverage, lerpedAverage)*50)+new Vector3(scaleX, scaleY, 1);
	}
}
