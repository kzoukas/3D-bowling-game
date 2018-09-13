using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSinglePlayer : MonoBehaviour {

	public Transform ball;
	public GameObject[] all_pins;
	public GameObject powerBallPanel;
	public bool ball_is_thrown;
	public int round;
	public Pins[] pins;
	public Slider ballPowerSlider;
	private Rigidbody ball_rigidBody;
	private Vector3 position_ball;
	private Quaternion rotation_ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime,midTime;
	private float dragDuration = 0.0f;
	private bool mouseUp = true;



	void Start () {

		ball_rigidBody = GetComponent<Rigidbody>();
		ball_rigidBody.useGravity = false;
		position_ball = ball.position;
		rotation_ball = ball.rotation;
		ball_is_thrown = false;
		round = 0;
		ballPowerSlider.value = 0;

	}

	// Update is called once per frame
	void Update () {
		if (!mouseUp) {
			midTime = Time.time;
			dragDuration = (midTime - startTime) * 40000;
			ballPowerSlider.value = dragDuration / 40000;
		}

		if ((!ball_is_thrown) && (round < 20)) {
			
			float moveHorizontal = Input.GetAxis ("Horizontal");
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0);
			if (ball.position.x >= 17.5 && ball.position.x <= 25) {
				ball_rigidBody.AddForce (movement * 20);
			} else if(ball.position.x <17.5){
				ball.position = new Vector3 (17.5f, 10.15f, -93.95f);
				moveHorizontal = Input.GetAxis ("Horizontal");
				movement = new Vector3 (moveHorizontal, 0.0f, 0);
			} else if(ball.position.x >25){
				ball.position = new Vector3 (25,  10.15f, -93.95f);
				moveHorizontal = Input.GetAxis ("Horizontal");
				movement = new Vector3 (moveHorizontal, 0.0f, 0);
			}
				//ball_rigidBody.AddForce (movement * 20);
		}

	}

	void OnMouseUp () {
		
		mouseUp = true;
		if ((!ball_is_thrown)&&(round < 20)) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;
			//float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			//float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			dragDuration = (endTime - startTime)*40000;
			Debug.Log (dragDuration);
			if ((dragDuration <= 25000) &&(dragDuration >=10000)) {
				ball_rigidBody.AddForce (transform.forward * dragDuration, ForceMode.Force);
				ball_rigidBody.useGravity = true;
				ball_is_thrown = true;
				ballPowerSlider.value = dragDuration/40000;
			} 
			else if(dragDuration > 25000){
				ball_rigidBody.AddForce (transform.forward * 25000, ForceMode.Force);
				ball_rigidBody.useGravity = true;
				ball_is_thrown = true;
				ballPowerSlider.value = 1;
			}else if(dragDuration <10000){
				ball_rigidBody.AddForce (transform.forward * 15000, ForceMode.Force);
				ball_rigidBody.useGravity = true;
				ball_is_thrown = true;
				ballPowerSlider.value = dragDuration/40000;
			}

		}

		powerBallPanel.SetActive (false);


	}

	void OnMouseDown () {
		if (! ball_is_thrown) {
			Debug.Log ("reee2");
			// Capture time & position of drag start
			//dragStart = Input.mousePosition;
			mouseUp=false;
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}





	public int round_number(){

		return round;

	}

	public void increase_round(){
		round++;
	}

	public void ball_Reset(){

		ball_is_thrown = false;
		ball.position = position_ball;
		ball.rotation= rotation_ball;
		ball_rigidBody.velocity = Vector3.zero;
		ball_rigidBody.angularVelocity = Vector3.zero;
		ball_rigidBody.useGravity = false;
		increase_round ();
		powerBallPanel.SetActive (true);
		dragDuration = 0;
		ballPowerSlider.value = 0;
		mouseUp = true;

	}

	public void Resets(){
		if (round % 2 == 0) {
			ball_Reset ();

			for (int i = 0; i < 10; i++) {
				if (pins[i].pin_has_fallen ()) {
					all_pins [i].SetActive (false);
				}
			}
		} else {
			ball_Reset ();
			for (int i = 0; i < 10; i++) {
				if (pins[i].pin_has_fallen ()) {
					all_pins [i].SetActive (true);
				}
			}
			for (int i = 0; i < 10; i++) {

				pins [i].pins_Reset ();
			}

		}
	}


}
