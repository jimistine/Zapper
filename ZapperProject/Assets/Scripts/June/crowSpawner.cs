using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowSpawner : MonoBehaviour {

	public GameObject [] enemies;
    public GameObject WireToSpawn;
	float randY;
	Vector2 whereToSpawn; 
	public float spawnRate;
    public float spawnRateMin;
    public float spawnRateMax;
	float nextSpawn;
	SceneController SC; 
	int getRandY; 
	public float gapSpace;

    public int TotalCrowsForLevel;
    public float BeginingDelay;

    public float DelayBeforeStart;

    public float TimeSinceFail;
    public int TimeSinceFailLevels = 1;
    public int TimeSinceFailLevelsCapMin = 4;
    public int TimeSinceFailLevelsCapMax = 12;
    public float StoreAddedTime;

    public bool IsSpawning =  true;
    public List<int> validChoices = new List<int>();

    // Use this for initialization
    void Start () {
		SC = FindObjectOfType<SceneController>();
        Debug.Log("Start");

        DelayBeforeStart = SC.DelayBeforeStartTime;
        spawnRate = spawnRateMin;

        foreach(GameObject x in enemies)
        {
            x.GetComponent<crowMove>().ChancetoSpawnCurrent = x.GetComponent<crowMove>().ChancetoSpawnStart;
        }
        validChoices.Add(1);
        validChoices.Add(2);
        validChoices.Add(3);
        validChoices.Add(4);
    }

	// Update is called once per frame
	void Update () {
        if (Time.time > DelayBeforeStart)
        {
            getRandY = Random.Range(1, 5);
            if (SC.WireOneObject.GetComponent<Wires>().canSpawn == false && SC.WireTwoObject.GetComponent<Wires>().canSpawn == false && SC.WireThreeObject.GetComponent<Wires>().canSpawn == false && SC.WireFourObject.GetComponent<Wires>().canSpawn == false)
            {
                gameObject.SetActive(false);
            }
            if (getRandY == 1 && SC.WireOneObject.GetComponent<Wires>().canSpawn== true)
            {
                randY = SC.WireOneObject.transform.position.y;
                WireToSpawn = SC.WireOneObject;
            }
            else if (SC.WireOneObject.GetComponent<Wires>().canSpawn == false)
            {
                validChoices.Remove(1);
                getRandY = validChoices[Random.Range(0, validChoices.Count)];
            }
            if (getRandY == 2 && SC.WireTwoObject.GetComponent<Wires>().canSpawn == true)
            {
                randY = SC.WireTwoObject.transform.position.y;
                WireToSpawn = SC.WireTwoObject;
            }
            else if (SC.WireTwoObject.GetComponent<Wires>().canSpawn == false)
            {
                validChoices.Remove(2);
                getRandY = validChoices[Random.Range(0, validChoices.Count)];
            }
            if (getRandY == 3 && SC.WireThreeObject.GetComponent<Wires>().canSpawn == true)
            {
                randY = SC.WireThreeObject.transform.position.y;
                WireToSpawn = SC.WireThreeObject;
            }
            else if (SC.WireThreeObject.GetComponent<Wires>().canSpawn == false)
            {
                validChoices.Remove(3);
                getRandY = validChoices[Random.Range(0, validChoices.Count)];
            }
            if (getRandY == 4 && SC.WireFourObject.GetComponent<Wires>().canSpawn == true)
            {
                randY = SC.WireFourObject.transform.position.y;
                WireToSpawn = SC.WireFourObject;
            }
            else if (SC.WireFourObject.GetComponent<Wires>().canSpawn == false)
            {
                validChoices.Remove(4);
                getRandY = validChoices[Random.Range(0, validChoices.Count)];
            }

            if (Time.time > nextSpawn && IsSpawning)
            {
                if (WireToSpawn.GetComponent<Wires>().canWin == true)
                {
                    spawnRate = spawnRate + 0.5f;
                }
                nextSpawn = Time.time + spawnRate;
                    
                if(SC.isMountainLevel == false)
                {
                    if (WireToSpawn.GetComponent<Wires>().PlayerStartRight == false)
                    {
                        whereToSpawn = new Vector2(WireToSpawn.GetComponent<Wires>().AnchorRight - 1, WireToSpawn.transform.position.y + gapSpace);
                    }
                    else if (WireToSpawn.GetComponent<Wires>().PlayerStartRight == true)
                    {
                        whereToSpawn = new Vector2(WireToSpawn.GetComponent<Wires>().AnchorLeft + 1, WireToSpawn.transform.position.y + gapSpace);
                    }
                }
                if(SC.isMountainLevel == true)
                {
                   // whereToSpawn = new Vector2(WireToSpawn.transform.position.x, Screen.height);
					whereToSpawn = new Vector2(WireToSpawn.transform.position.x, Camera.main.orthographicSize + (Camera.main.transform.position.y));
                }
                GameObject NewBird = Instantiate(enemies[SelectEnemyToSpawn()], whereToSpawn, Quaternion.identity);
                NewBird.GetComponent<crowMove>().CurrentWire = SetBirdWire();

            }
        }

        //add in function of escalating spawns and changing type chance over time.
        //need to track time since last reset/begining 
        TimeSinceFail = Time.time - (BeginingDelay - 1);
        //develop an increment to allow escalation
        if (TimeSinceFail> StoreAddedTime + (DelayBeforeStart + ((TimeSinceFailLevelsCapMax-(TimeSinceFailLevels-1)))))
        {
            StoreAddedTime += DelayBeforeStart + (TimeSinceFailLevelsCapMax - (TimeSinceFailLevels - 1));

            if (TimeSinceFailLevels < TimeSinceFailLevelsCapMax - (TimeSinceFailLevelsCapMin-1))
            {
                TimeSinceFailLevels+=1;
                if (WireToSpawn.GetComponent<Wires>().canWin == false)
                {
                    spawnRate = spawnRate - 0.25f;
                }

                enemies[1].GetComponent<crowMove>().ChancetoSpawnCurrent += .33f;
            }
            // Edit Spawn Rates for spawner / Edit Odds of enemy types
            //Debug.Log("Time"+TimeSinceFail);
            //spawnRate += 1+(1/(TimeSinceFailLevels));
        }
        //leave open for edits from story driven changes
    }
    GameObject SetBirdWire()
    {
        if (WireToSpawn == SC.WireOneObject)
        {
            return SC.WireOneObject;
        }
        else if (WireToSpawn == SC.WireTwoObject)
        {
            return SC.WireTwoObject;
        }
        else if (WireToSpawn == SC.WireThreeObject)
        {
            return SC.WireThreeObject;
        }
        else if (WireToSpawn == SC.WireFourObject)
        {
            return SC.WireFourObject;
        }
        else { return null; }
    }

    int SelectEnemyToSpawn()
    {
        int EnemyToSpawn = new int();
        float ShouldSpawnThisBird = new float();
        float TotalSpawnNum = new float();
        float ShouldSpawnStore = new float();
        int enemyNum = 0;
        Dictionary<float, int> WhatEnemyToSpawn = new Dictionary<float, int>();
        List<GameObject> enemiesToUse = new List<GameObject>();

        foreach(GameObject x in enemies)
        {
            if (x.GetComponent<crowMove>().ChancetoSpawnCurrent != 0)
            {
                enemiesToUse.Add(x);
                TotalSpawnNum += x.GetComponent<crowMove>().ChancetoSpawnCurrent;
            }
        }
        foreach (GameObject x in enemiesToUse)
        {
            enemyNum += 1;
            ShouldSpawnThisBird = x.GetComponent<crowMove>().ChancetoSpawnCurrent / TotalSpawnNum;
            ShouldSpawnStore += ShouldSpawnThisBird;

            WhatEnemyToSpawn.Add(ShouldSpawnStore, enemyNum);
        }
        float ValueStore = new float();
        ValueStore = Random.value;

        float Min = new float();
        float Max = new float();

        foreach (float x in WhatEnemyToSpawn.Keys)
        {
            Max = Min + x;
            if (ValueStore >= Max && ValueStore>= Min)
            {
                EnemyToSpawn = WhatEnemyToSpawn[x];
            }
            Min = Max;
        }
        return EnemyToSpawn;
    }
}


