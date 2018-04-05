using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

	public int delay; 
	public SpriteRenderer mySpriteRenderer;
	int counter;
	bool toggle=false;

	// Use this for initialization
	void Start () {

		mySpriteRenderer = gameObject.GetComponent<SpriteRenderer> (); 
		
	}

	public void flicker (SpriteRenderer spriteRen) {


	if(counter>=delay) { 
		counter = 0;

		toggle=!toggle;
		
		if(toggle) {
			spriteRen.enabled=true;
		}
		else {
			spriteRen.enabled=false;
		}

	}
	else {
		counter++;
		}

		 
	}
}