﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fusebox_script : MonoBehaviour {

	public Animator anim; 

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> (); 
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {


			anim.SetBool ("zap_bool", true); 
		}
		
	}

	public void fusebox_zap () {

		anim.SetBool ("zap_bool", true); 

	}

	public void fusebox_normal () {

		anim.SetBool ("zap_bool", false); 
	}
}