using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText; 
	public Button exitText;  

	// Use this for initialization
	void Start () {

		quitMenu.enabled = false; //quit menu is hidden until button is pressed
		
	}


	public void ExitPress() { //when QUIT button is pressed, quit sub-menu pops up


		quitMenu.enabled = true; 
		startText.enabled = false; 
		exitText.enabled = false; 


	}

	public void NoPress () { //functionality for the NO button

		quitMenu.enabled = false; 
		startText.enabled = true; 
		exitText.enabled = true; 

	}

	public void startLevel () { //go into the game 

		SceneManager.LoadScene ("Main"); 


	}

	public void ExitGame () { //functionality for the YES button, quits the game 

		Application.Quit (); 

	}

}
