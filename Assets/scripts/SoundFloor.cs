using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFloor : MonoBehaviour {
	public AudioSource audio;
	// Use this for initialization
	void Start () {
		
	}


	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.name == "Ball") {

			audio.Play ();
		}
	}
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == "Ball") {

			audio.Stop ();
		}
	}



	// Update is called once per frame
	void Update () {
		
	}
}
