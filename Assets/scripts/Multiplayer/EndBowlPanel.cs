using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndBowlPanel : MonoBehaviour {

	//public Image image;
	public GameObject canvas;
	public Button startText;
	public Button exitText;

	void Start(){
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		startText.enabled = true;
		exitText.enabled = true;
	}
	// Use this for initialization
	void Awake () {
		canvas.SetActive (false);
	}
	
	// Update is called once per frame
	public void PlayAgain(){
		Application.LoadLevel (1);
	}
	public void Quit(){
		Application.LoadLevel (0);
	}
}
