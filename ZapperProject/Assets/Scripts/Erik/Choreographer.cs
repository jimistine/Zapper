using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choreographer : MonoBehaviour {
    public SceneController SC;
    public crowSpawner Spawner;
    public GameObject PlayerObj;

    public int currentBeatNum;
    public int [] BeatNum;
    public int[] SpawnNum;
    public int[] SpawnType;
    public float [] BeatTime;
    public float[] RateOfSpawn;
    public int[] SpawnAtATime;
    Dictionary<int, float> BeatTimeNum = new Dictionary<int, float>();
    Dictionary<int, int> BeatsValueType = new Dictionary<int, int>();
    Dictionary<int, int> BeatsValueNum = new Dictionary<int, int>();
    Dictionary<int, float> BeatsValueRate = new Dictionary<int, float>();
    Dictionary<int, int> BeatsAtATime = new Dictionary<int, int>();
    float TimeOfBeat;
    Vector2 whereToSpawn;
    int MicroBeatNum =1;
    bool IsCoreographerEnding = false;
    // set up beats and the times they need to be run
    // each beat needs to know what its spawning, how many and over how much time
    //how much time will equal next beats time y minus this beats time x (y - x = total time of beat)
    //what is being spawned can be pulled form the public list of game objects on the arcade spawner object.
    //how many will need to be manually set, or pre determined in the inspector.

        // add functionality for disabling the arcade spanwer, currently always disabled, on and off?
        // add restartability?

    public GameObject WireCoreographer;
    public int WireNum;


    // Use this for initialization
    void Start () {
        SC = FindObjectOfType<SceneController>();
        Spawner = FindObjectOfType<crowSpawner>();
        AssignBeatsTimeNum();
        AssignBeatsValuesNum();
        AssignBeatsValuesType();
        AssignBeatsSpawnRate();
        AssignBeatsAtATime();
        SetWireNum();

        DissableArcadeSpawner();
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(BeatsValueType[0]);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(BeatsValueType[1]);
        }
        ///
        if (currentBeatNum > 0 && IsCoreographerEnding == false && BeatsValueNum[currentBeatNum] != 0)
        {
            TimeOfBeat = BeatTimeNum[currentBeatNum] - BeatTimeNum[currentBeatNum-1];
            //Debug.Log("Time of wire " + WireNum + " Time " + TimeOfBeat);
            //how to do spawn rate?
            if ((TimeOfBeat / BeatsValueRate[currentBeatNum]) * BeatsAtATime[currentBeatNum] > BeatsValueNum[currentBeatNum])
            {
                Debug.LogError("Value TotalTime/RateSpawn * AtATime greater then TotalSpawn value. " + " Coreographer Wire"+WireNum);
            }
            else
            {
                //begin spawning; type, at rate, at a time.
                float CurrentTimeInBeat = Time.time - BeatTimeNum[currentBeatNum - 1];
                //Debug.Log(CurrentTimeInBeat);

                if (CurrentTimeInBeat >= BeatsValueRate[currentBeatNum]*MicroBeatNum)
                {
                    Debug.Log("Instantiate Wire " + WireNum);
                    //spawn the number of birds, type of birds
                    //increment time to adjust for next micro beat
                    if (WireCoreographer.GetComponent<Wires>().PlayerStartRight == false)
                    {
                        whereToSpawn = new Vector2(WireCoreographer.GetComponent<Wires>().AnchorRight, WireCoreographer.transform.position.y + Spawner.gapSpace);
                    }
                    else if (WireCoreographer.GetComponent<Wires>().PlayerStartRight == true)
                    {
                        whereToSpawn = new Vector2(WireCoreographer.GetComponent<Wires>().AnchorLeft, WireCoreographer.transform.position.y + Spawner.gapSpace);
                    }
                    GameObject NewBird = Instantiate(Spawner.enemies[BeatsValueType[currentBeatNum]], whereToSpawn, Quaternion.identity);
                    NewBird.GetComponent<crowMove>().CurrentWire = WireCoreographer;
                    MicroBeatNum++;
                }
            }
        }
        if (Time.time > BeatTimeNum[currentBeatNum] && BeatTimeNum.Count > currentBeatNum+1)
        {
            currentBeatNum++;
            MicroBeatNum = 1;
            Debug.Log("Increase beat" + " Wire "+WireNum);
        }
        if (BeatTimeNum.Count <= currentBeatNum+1)
        {
            Debug.Log("Ending coreography" + " Wire " + WireNum);
            IsCoreographerEnding = true;
        }

    }
    public void DissableArcadeSpawner()
    {
        Spawner.IsSpawning = false;
    }
    public void SetWireNum()
    {
        if (WireCoreographer == SC.WireOneObject)
        {
            WireNum = 1;
        }
        if (WireCoreographer == SC.WireTwoObject)
        {
            WireNum = 2;
        }
        if (WireCoreographer == SC.WireThreeObject)
        {
            WireNum = 3;
        }
        if (WireCoreographer == SC.WireFourObject)
        {
            WireNum = 4;
        }
    }
    public void AssignBeatsTimeNum()
    {
        BeatTimeNum.Clear();
        foreach (int X in BeatNum)
        {
            BeatTimeNum.Add(X, BeatTime[X]);
        }
    }
    public void AssignBeatsValuesType()
    {
        BeatsValueType.Clear();
        foreach (int X in BeatNum)
        {
            BeatsValueType.Add(X, SpawnType[X]);
        }
    }
    public void AssignBeatsValuesNum()
    {
        BeatsValueNum.Clear();
        foreach (int X in BeatNum)
        {
            BeatsValueNum.Add(X, SpawnNum[X]);
        }
    }
    public void AssignBeatsSpawnRate()
    {
        BeatsValueRate.Clear();
        foreach (int X in BeatNum)
        {
            BeatsValueRate.Add(X, RateOfSpawn[X]);
        }
    }
    public void AssignBeatsAtATime()
    {
        BeatsAtATime.Clear();
        foreach (int X in BeatNum)
        {
            BeatsAtATime.Add(X, SpawnAtATime[X]);
        }
    }
}
