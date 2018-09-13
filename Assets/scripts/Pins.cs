using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {

	public Transform pin;
	private Rigidbody pin_rigidBody;
	private Vector3 position_pin;
	public AudioSource hitOnePin;

	// Use this for initialization
	void Start () {
		pin_rigidBody = GetComponent<Rigidbody>();
		position_pin = pin.position;
	}

	void OnCollisionEnter(Collision collision){
		if ((collision.gameObject.name == "Ball")&& (pin_has_fallen()==true)){
			
				hitOnePin.Play ();


		}
	}
	public void pins_Reset(){


		pin_rigidBody.angularVelocity = Vector3.zero;
		pin_rigidBody.velocity = Vector3.zero;
		pin.position = position_pin;
		pin.rotation = Quaternion.identity;
	
	}

	public bool pin_has_fallen(){
	
		Vector3 pinsUpVector = pin.up;
		if (Vector3.Angle (pinsUpVector, Vector3.up) > 1f) {
		
			return true;

		} else {
			
			return false;
		}

	}
}
