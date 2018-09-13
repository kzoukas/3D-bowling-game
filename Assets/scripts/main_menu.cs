using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class main_menu : MonoBehaviour {

	public GameObject quitMenu;
	public GameObject mainMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () {
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.SetActive(false);
		mainMenu.SetActive(true);
	}
	
	// Update is called once per frame
	public void ExitPress() {

		mainMenu.SetActive(false);
		quitMenu.SetActive(true);
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void NoPress() {

		mainMenu.SetActive(true);
		quitMenu.SetActive(false);
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void startLevel() {

		Application.LoadLevel (1);
	}
	public void startSingle() {

		Application.LoadLevel (2);
	}

	public void exitGame() {

		Application.Quit();
	}
}
