using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowSpawner : MonoBehaviour {

	public GameObject [] enemies; 
	float randY;
	Vector2 whereToSpawn; 
	public float spawnRate; 
	public float nextSpawn;
	SceneController SC; 
	int getRandY; 

	public float gapSpace; 

	// Use this for initialization
	void Start () {

		SC = FindObjectOfType<SceneController>();


	}

	// Update is called once per frame
	void Update () {

		getRandY = Random.Range (1, 4); 

		if (getRandY == 1) {

			randY = SC.WireOneObject.transform.position.y;

		}

		if (getRandY == 2) {

			randY = SC.WireTwoObject.transform.position.y; 
		}

		if (getRandY == 3) {

			randY = SC.WireThreeObject.transform.position.y; 

		}

		if (getRandY == 4) {

			randY = SC.WireFourObject.transform.position.y; 

		}


		if (Time.time > nextSpawn) {


			nextSpawn = Time.time + spawnRate; 
			whereToSpawn = new Vector2 (transform.position.x, randY+gapSpace); 
			Instantiate (enemies[Random.Range(0,enemies.Length)], whereToSpawn, Quaternion.identity);

		}

	}


}


