using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour {

	public Animator anim; 

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> (); 

	}

	// Update is called once per frame
	void Update () {

	}

	//zap 

	public void platform_zap () {

		anim.SetBool ("zap_bool", true); 
		Debug.Log ("platform 1 zapped!"); 

	}

	public void platform_zap_2 () {

		anim.SetBool ("zap_bool2", true); 
		Debug.Log ("platform 2 zapped!"); 

	}

	public void platform_zap_3 () {

		anim.SetBool ("zap_bool_3", true); 
		Debug.Log ("platform 3 zapped!"); 

	}

	public void platform_zap_4 () {

		anim.SetBool ("zap_bool_4", true); 
		Debug.Log ("platform 4 zapped!"); 

	}	


	//normal

	public void platform_normal () {

		anim.SetBool ("zap_bool", false); 
	}

	public void platform_normal_2 () {

		anim.SetBool ("zap_bool2", false); 

	}

	public void platform_normal_3 () {

		anim.SetBool ("zap_bool_3", false); 

	}

	public void platform_normal_4 () {

		anim.SetBool ("zap_bool_4", false); 

	}	


}
