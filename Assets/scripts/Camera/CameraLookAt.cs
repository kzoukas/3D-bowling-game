using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

	public Transform target;
	private CameraIntroMove cameraIntro;
	public Ball ball;


	void Start(){
	
		cameraIntro = GetComponent<CameraIntroMove> ();
		cameraIntro.enabled = false;
	
	}

	// Update is called once per frame
	void Update () {
		if (ball.transform.position.z < 107f) {

			transform.position = (target.position - new Vector3 (0, -6, 25));


		}
	}
}
