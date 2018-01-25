using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireTracker : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (gameObject.name == "Wire_1"){
			GM.Me.PlayerLocation = 1;
			Debug.Log("On " + gameObject.name);
		}
		if (gameObject.name == "Wire_2"){
			GM.Me.PlayerLocation = 2;
			Debug.Log("On " + gameObject.name);
		}
		if (gameObject.name == "Wire_3"){
			GM.Me.PlayerLocation = 3;
			Debug.Log("On " + gameObject.name);
		}
		if (gameObject.name == "Wire_4"){
			GM.Me.PlayerLocation = 4;
			Debug.Log("On " + gameObject.name);
		}
	}
	
}
