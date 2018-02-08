using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowMove : MonoBehaviour {

	public float crowSpeed; 
	public float startWait; 
	public float pauseTime; 
	public float stopSpeed = 0; 
	public float goSpeed; 
	public int randomTime; 
 

	// Use this for initialization
	void Start () {

		StartCoroutine (wait()); 
		
	}
	
	// Update is called once per frame
	void Update () {

		randomTime = Random.Range (2, 4); 
		pauseTime = Random.Range (1, 3);


		transform.Translate (goSpeed, 0, 0); 
		
	}

	IEnumerator wait () {

		goSpeed = stopSpeed; 
		yield return new WaitForSeconds (1); 
		goSpeed = crowSpeed; 
		StartCoroutine (pause ()); 



	}

	IEnumerator pause() {
	
		yield return new WaitForSeconds (randomTime); 
		goSpeed = 0; 
		yield return new WaitForSeconds (pauseTime); 
		goSpeed = crowSpeed; 
		StartCoroutine (pause ()); 

	}


}
