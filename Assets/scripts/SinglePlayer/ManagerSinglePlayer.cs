using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSinglePlayer : MonoBehaviour {

	//private List <int> rounds = new List<int> ();
	public GameObject panel;
	public Text score_result;
	public int[] roundScore;
	public BallSinglePlayer ball;
	public ScoreSinglePlayer panelScore;
	private int SumScore1;


	private int round;


	void Start () {
		for (int i = 0; i < roundScore.Length; i++) {
			roundScore [i] = 0;
		}

	}

	public void gaming(int score){

		round = ball.round_number ();

		if (round < 19) {

			roundScore [round] = score;
			panelScore.ScoreDisplay (roundScore);
			if (round % 2 == 1) {
				panelScore.RoundScoreDisplay (roundScore);
			}

		} else if(round==19) {
			roundScore [round] = score;
			panelScore.ScoreDisplay (roundScore);
			panelScore.RoundScoreDisplay (roundScore);

			SumScore1=panelScore.ScoreSum_Player1 ();
			Debug.Log ("s1"+SumScore1);
			Invoke ("SumFunction", 1);


		}

	}

	// Use this for initialization




	// Update is called once per frame
	public void SumFunction () {
		panel.SetActive (true);
			score_result.text =SumScore1.ToString();

	}
}

