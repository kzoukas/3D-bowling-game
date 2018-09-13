using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {
	public AudioSource ball_roll_sound;
	public AudioSource pins_hit_sound;
	public Transform canvas;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			
			if (canvas.gameObject.activeInHierarchy == false) 
			{
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
				if (ball_roll_sound.isPlaying) {
					ball_roll_sound.Pause ();
				}else if(pins_hit_sound.isPlaying){
					pins_hit_sound.Pause ();
				}

			} else 
			{
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
				ball_roll_sound.UnPause ();
				pins_hit_sound.UnPause ();
			}
		
		}

	}

	public void Resume(){
		canvas.gameObject.SetActive (false);
		Time.timeScale = 1;
	}
	public void Quit(){
		Application.LoadLevel (0);
	}

}
