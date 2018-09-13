using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	//private List <int> rounds = new List<int> ();
	public GameObject panel;
	public Text score_result;
	public Text winner_announce;
	public int[] roundScore;
	public Ball ball;
	public PanelScore panelScore;
	private int SumScore1;
	private int SumScore2;

	private int round;


	void Start () {
		for (int i = 0; i < roundScore.Length; i++) {
			roundScore [i] = 0;
		}

	}

	public void gaming(int score){
		
		round = ball.round_number ();
		Debug.Log (round);
		if (round < 39) {
			Debug.Log ("re"+round);
			roundScore [round] = score;
			panelScore.ScoreDisplay (roundScore);
			if (round % 2 == 1) {
				panelScore.Score_round (roundScore);
			}
		} else if(round==39) {
			roundScore [round] = score;
			panelScore.ScoreDisplay (roundScore);
			panelScore.Score_round (roundScore);

			SumScore1=panelScore.ScoreSum_Player1 ();
			SumScore2=panelScore.ScoreSum_Player2 ();

			Debug.Log ("s1"+SumScore1);
			Debug.Log ("s2"+SumScore2);
			Invoke ("SumFunction", 1);


		}
	
	}

	// Use this for initialization



	
	// Update is called once per frame
	public void SumFunction () {
		panel.SetActive (true);
		if (SumScore1 > SumScore2) {
			winner_announce.text = "Player 1 wins!";
			score_result.text =SumScore1.ToString()+"-"+SumScore2.ToString();
		}else if(SumScore1 < SumScore2){
			winner_announce.text = "Player 2 wins";
			score_result.text = SumScore1.ToString()+"-"+SumScore2.ToString();
		}else{
			winner_announce.text="It's a tie";
			score_result.text =SumScore1.ToString()+"-"+SumScore2.ToString();
		}
	}
}
