using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowSpawner : MonoBehaviour {

	public GameObject [] enemies;
    public GameObject WireToSpawn;
	float randY;
	Vector2 whereToSpawn; 
	public float spawnRate; 
	public float nextSpawn;
	SceneController SC; 
	int getRandY; 
	public float gapSpace;

    public int TotalCrowsForLevel;
    public float BeginingDelay;

	// Use this for initialization
	void Start () {

		SC = FindObjectOfType<SceneController>();


	}

	// Update is called once per frame
	void Update () {

		getRandY = Random.Range (1, 5); 

		if (getRandY == 1) {

			randY = SC.WireOneObject.transform.position.y;
            WireToSpawn = SC.WireOneObject;
        }

		if (getRandY == 2) {

			randY = SC.WireTwoObject.transform.position.y;
            WireToSpawn = SC.WireTwoObject;
        }

		if (getRandY == 3) {

			randY = SC.WireThreeObject.transform.position.y;
            WireToSpawn = SC.WireThreeObject;
        }

		if (getRandY == 4) {

			randY = SC.WireFourObject.transform.position.y;
            WireToSpawn = SC.WireFourObject;
        }


		if (Time.time > nextSpawn) {


			nextSpawn = Time.time + spawnRate; 

            if (WireToSpawn.GetComponent<Wires>().PlayerStartRight == false)
            {
                whereToSpawn = new Vector2(WireToSpawn.GetComponent<Wires>().AnchorRight, randY + gapSpace);
            }
            else if (WireToSpawn.GetComponent<Wires>().PlayerStartRight == true)
            {
                whereToSpawn = new Vector2(WireToSpawn.GetComponent<Wires>().AnchorLeft, randY + gapSpace);
            }

            GameObject NewBird = Instantiate (enemies[Random.Range(0,enemies.Length)], whereToSpawn, Quaternion.identity);
            NewBird.GetComponent<crowMove>().CurrentWire = SetBirdWire();
            
		}
        

    }
    GameObject SetBirdWire()
    {
        if (getRandY == 1)
        {
            return SC.WireOneObject;
        }
        else if (getRandY == 2)
        {
            return SC.WireTwoObject;
        }
        else if (getRandY == 3)
        {
            return SC.WireThreeObject;
        }
        else if (getRandY == 4)
        {
            return SC.WireFourObject;
        }
        else { return null; }
    }

}


