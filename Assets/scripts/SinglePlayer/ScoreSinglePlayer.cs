using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSinglePlayer : MonoBehaviour {

	public Text[] scores_text;
	public Text[] round_scores_text;
	public int[] total_scores;
	public BallSinglePlayer ball;
	private int sum1,sum2; 
	private int j=0;
	private int round;

	public void ScoreDisplay(int[] roundScores){

		round = ball.round_number ();

		for (int i = 0; i < roundScores.Length; i++) {

			if (roundScores [i] == -1) {
				scores_text [i].text = " ";
			}else if (roundScores [i] == 10) {
				scores_text [i].text = "X";
				roundScores [i + 1] = 0;
			}else if (roundScores [i] == 0) {
				scores_text [i].text = "-";
			}else if (i>0){
				if ((roundScores [i] + roundScores [i - 1] == 10) && (roundScores [i - 1]==10)){

					scores_text [i].text = " ";
				}else if (roundScores [i] + roundScores [i - 1] == 10){

					scores_text [i].text = "/";
				}else{
					scores_text [i].text =  roundScores[i].ToString ();
				}
			}else{
				scores_text [i].text =  roundScores[i].ToString ();
			}
		}
	}

	public void RoundScoreDisplay(int[] roundScores){
		round = ball.round_number ();
		int j = 0;
		for (int i = 0; i < roundScores.Length - 1; i++) {
			sum1 = 0;
			sum1 = roundScores [i] + roundScores [i + 1];
			total_scores [j] = sum1;

			if (i % 2 == 0) {
				if ((i > 5) && (round > 5)) {
				
					if ((roundScores [i - 2] == 10) && (roundScores [i - 4] == 10) && (roundScores [i - 6] == 10)) {              //3 strikes in a row
					
						total_scores [j - 1] = 10 + sum1;
						total_scores [j - 2] = 20 + sum1;
						total_scores [j - 3] = 30;

						round_scores_text [j - 1].text = total_scores [j - 1].ToString ();
						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();
						round_scores_text [j - 3].text = total_scores [j - 3].ToString ();


					} else if ((roundScores [i - 2] == 10) & (roundScores [i - 4] == 10)) {									//2 strikes in a row

						total_scores [j - 1] = 10 + sum1;
						total_scores [j - 2] = 20 + sum1;

						round_scores_text [j - 1].text = total_scores [j - 1].ToString ();
						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();


					} else if (roundScores [i - 2] == 10) {																//1 strike
							
						total_scores [j - 1] = sum1 + total_scores [j - 1];
						round_scores_text [j - 1].text = total_scores [j - 1].ToString ();

					} 
				} else if ((i > 3) && (round > 3)) {																
				
					if ((roundScores [i - 2] == 10) & (roundScores [i - 4] == 10)) {										//2 strikes in a row
					
						total_scores [j - 1] = 10 + sum1;
						total_scores [j - 2] = 20 + sum1;

						round_scores_text [j - 1].text = total_scores [j - 1].ToString ();
						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();


					} else if (roundScores [i - 2] == 10) {																//1 strike

						total_scores [j - 1] = sum1 + total_scores [j - 1];
						round_scores_text [j - 1].text = total_scores [j - 1].ToString ();

					} 
				} else if ((i > 1) && (round > 1)) {															//1 strike
					//Debug.Log("mpikaaa1");

					if (roundScores [i - 2] == 10) {

						total_scores [j - 1] = sum1 + total_scores [j - 1];
						round_scores_text [j - 1].text = total_scores [j - 1].ToString ();

					} 

				}
				if ((i > 1) && (round > 1)) {	
					if ((roundScores [i - 2] + roundScores [i - 1] == 10) && (roundScores [i - 2] != 10)) {		//spare (and not strike)

						total_scores [j - 1] = total_scores [j - 1] + roundScores [i];						
						round_scores_text [j - 1].text = total_scores [j - 1].ToString ();
					}
				}
				if (sum1 == 0) {
					round_scores_text [j].text = " ";

					i = i + 1;
					j = j + 1;
				} else {
					round_scores_text [j].text = sum1.ToString ();

					i = i + 1;
					j = j + 1;
				}

			}
		}
	}


	public int ScoreSum_Player1(){
		sum2 = 0;
		for (int i = 0; i < total_scores.Length; i++) {

			sum2 += total_scores [i];

		}
		Debug.Log ("sum2"+sum2);
		return sum2;
	}



}
