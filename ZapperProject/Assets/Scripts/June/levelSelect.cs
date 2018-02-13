using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class levelSelect : MonoBehaviour {


	public Button levelOne; 
	public Button levelTwo;
	public Button levelThree; 
	public Button levelFour; 
	public Button levelIntro; 
	public Button levelSix; 
	public Button levelSeven; 
	public Button levelEight; 
	public Button levelNine; 

	public Canvas quitMenu;
	public Button exitText; 


	// Use this for initialization
	void Start () {

		quitMenu.enabled = false; //quit menu is hidden until button is pressed

	
	}


	public void ExitPress() { //when QUIT button is pressed, quit sub-menu pops up


		quitMenu.enabled = true; 
		exitText.enabled = false; 


	}

	public void NoPress () { //functionality for the NO button

		quitMenu.enabled = false; 
		exitText.enabled = true; 

	}

	public void ExitGame () { //functionality for the YES button, quits the game 

		Application.Quit (); 

	}


	public void startLevelIntro () { //go into the game 

		SceneManager.LoadScene ("ErikWireTracking"); 


	}

}