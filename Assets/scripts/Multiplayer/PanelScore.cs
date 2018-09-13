using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScore : MonoBehaviour {

	public Text[] scores_text;
	public Text[] round_scores_text;
	public int[] total_scores;
	public Ball ball;
	private int sum1; 
	private int sum2; 
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
			}else if (i>0) {
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

	public void Score_round(int[] roundScores){

		round = ball.round_number ();
		int j = 0;
		for (int i = 0; i < roundScores.Length - 1; i++) {
			sum1 = 0;
			sum1 = roundScores [i] + roundScores [i + 1];
			total_scores [j] = sum1;

			if (i % 2 == 0) {
				if ((i > 11) && (round > 11)) {

					if ((roundScores [i - 4] == 10) && (roundScores [i - 8] == 10) && (roundScores [i - 12] == 10)) {              //3 strikes in a row

						total_scores [j - 2] = 10 + sum1;
						total_scores [j - 4] = 20 + sum1;
						total_scores [j - 6] = 30;

						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();
						round_scores_text [j - 4].text = total_scores [j - 4].ToString ();
						round_scores_text [j - 6].text = total_scores [j - 6].ToString ();


					} else if ((roundScores [i - 4] == 10) & (roundScores [i - 8] == 10)) {									//2 strikes in a row

						total_scores [j - 2] = 10 + sum1;
						total_scores [j - 4] = 20 + sum1;

						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();
						round_scores_text [j - 4].text = total_scores [j - 4].ToString ();


					} else if (roundScores [i - 4] == 10) {																//1 strike

						total_scores [j - 2] = sum1 + total_scores [j - 2];
						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();

					} 
				} else if ((i > 7) && (round > 7)) {																

					if ((roundScores [i - 4] == 10) & (roundScores [i - 8] == 10)) {									//2 strikes in a row

						total_scores [j - 2] = 10 + sum1;
						total_scores [j - 4] = 20 + sum1;

						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();
						round_scores_text [j - 4].text = total_scores [j - 4].ToString ();


					} else if (roundScores [i - 4] == 10) {																//1 strike

						total_scores [j - 2] = sum1 + total_scores [j - 2];
						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();

					} 
				} else if ((i > 3) && (round > 3)) {															//1 strike
					//Debug.Log("mpikaaa1");

					if (roundScores [i - 4] == 10) {																//1 strike

						total_scores [j - 2] = sum1 + total_scores [j - 2];
						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();

					} 

				}
				if ((i > 3) && (round > 3)) {	
					if ((roundScores [i - 4] + roundScores [i - 3] == 10) && (roundScores [i - 4] != 10)) {		//spare (and not strike)

						total_scores [j - 2] = total_scores [j - 2] + roundScores [i];						
						round_scores_text [j - 2].text = total_scores [j - 2].ToString ();
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
	

		sum1 = total_scores [0]+total_scores [2]+total_scores [4]+total_scores [6]+total_scores [8]+total_scores [10]+total_scores [12]+total_scores [14]+total_scores [16]+total_scores [18];

		Debug.Log ("sum1"+sum1);
		return sum1;
	}
	public int ScoreSum_Player2(){

			sum2 = total_scores [1]+total_scores [3]+total_scores [5]+total_scores [7]+total_scores [9]+total_scores [11]+total_scores [13]+total_scores [15]+total_scores [17]+total_scores [19];

		Debug.Log ("sum2"+sum2);
		return sum2;
	}




}
