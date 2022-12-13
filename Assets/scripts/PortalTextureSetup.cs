using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	// Adapted from the Brackeys portal tutorial: https://www.youtube.com/watch?v=cuQao3hEKfs

	public Camera cameraA;
	public Camera cameraB;

	public Material cameraMatA;
	public Material cameraMatB;

	// Start is called before the first frame update
	void Start() {
		if (cameraA.targetTexture != null) {
			cameraA.targetTexture.Release();
		}
		// Sets the camera's render texture to the size of the screen
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatA.mainTexture = cameraA.targetTexture;

		if (cameraB.targetTexture != null) {
			cameraB.targetTexture.Release();
		}
		// Sets the camera's render texture to the size of the screen
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatB.mainTexture = cameraB.targetTexture;
	}
}
