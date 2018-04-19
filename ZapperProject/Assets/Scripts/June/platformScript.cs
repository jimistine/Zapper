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

<<<<<<< HEAD
		//test function on keypress
		if (Input.GetKeyDown (KeyCode.A)) {


			anim.SetBool ("zap_bool", true); 

			anim.SetBool ("zap_bool_2", true); 

			anim.SetBool ("zap_bool_3", true); 

			anim.SetBool ("zap_bool_4", true);
		}

=======
>>>>>>> June
	}

	//zap 

	public void platform_zap () {

		anim.SetBool ("zap_bool", true); 
<<<<<<< HEAD
=======
		Debug.Log ("platform 1 zapped!"); 
>>>>>>> June

	}

	public void platform_zap_2 () {

<<<<<<< HEAD
		anim.SetBool ("zap_bool_2", true); 
=======
		anim.SetBool ("zap_bool2", true); 
		Debug.Log ("platform 2 zapped!"); 
>>>>>>> June

	}

	public void platform_zap_3 () {

		anim.SetBool ("zap_bool_3", true); 
<<<<<<< HEAD
=======
		Debug.Log ("platform 3 zapped!"); 
>>>>>>> June

	}

	public void platform_zap_4 () {

		anim.SetBool ("zap_bool_4", true); 
<<<<<<< HEAD


	}
=======
		Debug.Log ("platform 4 zapped!"); 

	}	

>>>>>>> June

	//normal

	public void platform_normal () {

		anim.SetBool ("zap_bool", false); 
	}

	public void platform_normal_2 () {

<<<<<<< HEAD
		anim.SetBool ("zap_bool_2", false); 
=======
		anim.SetBool ("zap_bool2", false); 
>>>>>>> June

	}

	public void platform_normal_3 () {

		anim.SetBool ("zap_bool_3", false); 

	}

	public void platform_normal_4 () {

		anim.SetBool ("zap_bool_4", false); 

<<<<<<< HEAD
	}
=======
	}	


>>>>>>> June
}
