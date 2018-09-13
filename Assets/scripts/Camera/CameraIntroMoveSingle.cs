using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntroMoveSingle : MonoBehaviour {

	// Use this for initialization
	public Transform startMarker;
	public Transform endMarker;
	public GameObject ballForceShow;
	public float speed = 0.3F;
	private float startTime;
	private float journeyLength;
	private CameraLookAtSingle cameraLook;
	public Transform ball;
	public GameObject light;
	public GameObject[] spots;

	void Start() {
		cameraLook = GetComponent<CameraLookAtSingle> ();

		startTime = Time.time;
		ballForceShow.SetActive (false);
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	void Update() {


		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
		if (transform.position.z > -119f ) {
			light.SetActive (false);
			for (int i = 0; i < spots.Length; i++) {
				spots [i].SetActive (true);
			}
			ballForceShow.SetActive (true);
			cameraLook.enabled = true;
		}
	}
}
