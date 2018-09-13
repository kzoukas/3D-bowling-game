using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterSound : MonoBehaviour {

	public AudioSource gutterEnterAudio;


	void Start(){
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Ball") {
			gutterEnterAudio.Play ();
		
		}
	}
	void OnCollisionExit(Collision collision){
		if (collision.gameObject.name == "Ball") {
			gutterEnterAudio.Stop ();

		}
	}


}
