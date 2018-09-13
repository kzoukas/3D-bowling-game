using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountPins : MonoBehaviour {

	public AudioSource audio;
	public Manager manager;
	public Text currentScore;
	public Text[] scores_text;

	public bool round_completed;
	public Ball ball;
	private bool ball_is_out;
	private int current_score;


	void Start () {
		currentScore.text = "0";
		ball_is_out = false;
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.name == "Ball") {

			//audio.Play ();

		}
	}

	void OnTriggerExit (Collider collider) {
		if (!ball_is_out) {
			if (collider.gameObject.name == "Ball") {
				ball_is_out = true;
				Invoke ("roundCompleted", 4);

			}
		}
	}

	public void roundCompleted (){

		current_score = showScore ();
		manager.gaming (current_score);

		if (current_score == 10) {
			currentScore.text = "STRIKE!!";
			ball.increase_round ();
			manager.gaming (0);

		} 
		ball.Resets ();
		ball_is_out = false;
	}
	public int showScore(){

		int score = 0;

		foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
			if (pin.pin_has_fallen()) {
				score++;
			}
		}

		return score;
	}

	void Update(){
	
		if (current_score == 10) {
			currentScore.text = "STRIKE!!";


		}
		else {

			currentScore.text = showScore ().ToString();

		}	
	}
}

