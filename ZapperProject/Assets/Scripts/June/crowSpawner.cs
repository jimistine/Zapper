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
	}

	// Update is called once per frame
	void Update () {
        if (Time.time > DelayBeforeStart)
        {
            getRandY = Random.Range(1, 5);

            if (getRandY == 1)
            {
                randY = SC.WireOneObject.transform.position.y;
                WireToSpawn = SC.WireOneObject;
            }
            if (getRandY == 2)
            {
                randY = SC.WireTwoObject.transform.position.y;
                WireToSpawn = SC.WireTwoObject;
            }
            if (getRandY == 3)
            {
                randY = SC.WireThreeObject.transform.position.y;
                WireToSpawn = SC.WireThreeObject;
            }
            if (getRandY == 4)
            {
                randY = SC.WireFourObject.transform.position.y;
                WireToSpawn = SC.WireFourObject;
            }

            if (Time.time > nextSpawn && IsSpawning)
            {
                nextSpawn = Time.time + spawnRate;

                if (WireToSpawn.GetComponent<Wires>().PlayerStartRight == false)
                {
                    whereToSpawn = new Vector2(WireToSpawn.GetComponent<Wires>().AnchorRight, randY + gapSpace);
                }
                else if (WireToSpawn.GetComponent<Wires>().PlayerStartRight == true)
                {
                    whereToSpawn = new Vector2(WireToSpawn.GetComponent<Wires>().AnchorLeft, randY + gapSpace);
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
                spawnRate = spawnRate - 0.25f;
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


