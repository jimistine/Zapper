using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmScript : MonoBehaviour {

	public Animator anim; 

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> (); 

	}

	// Update is called once per frame
	void Update () {

		//test function on keypress
		if (Input.GetKeyDown (KeyCode.A)) {


			anim.SetBool ("zap_bool", true); 

			anim.SetBool ("zap_bool_2", true); 

			anim.SetBool ("zap_bool_3", true); 

			anim.SetBool ("zap_bool_4", true);
		}

	}

	//zap 

	public void alarm_zap () {

		anim.SetBool ("zap_bool", true); 

	}

	public void alarm_zap_2 () {

		anim.SetBool ("zap_bool_2", true); 

	}

	public void alarm_zap_3 () {

		anim.SetBool ("zap_bool_3", true); 

	}

	public void alarm_zap_4 () {

		anim.SetBool ("zap_bool_4", true); 


	}

	//normal

	public void alarm_normal () {

		anim.SetBool ("zap_bool", false); 
	}

	public void alarm_normal_2 () {

		anim.SetBool ("zap_bool_2", false); 

	}

	public void alarm_normal_3 () {

		anim.SetBool ("zap_bool_3", false); 

	}

	public void alarm_normal_4 () {

		anim.SetBool ("zap_bool_4", false); 

	}
}
