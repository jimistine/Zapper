using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {
    // find and store the four wires positions, (Y) 
    // Use wire positions to controll player Movment (Y)
    // Use wire positions to inform bird spawns
    public int RoundNum;

    public GameObject WireOneObject;
    public GameObject WireTwoObject;
    public GameObject WireThreeObject;
    public GameObject WireFourObject;
    public GameObject PlayerObject;
    public GameObject ScoreUI;
    public GameObject ClocksBrokenUI;
    public GameObject TimeRemainingUI;

	public GameObject plusOne; 

    public bool CannotLose;
    public bool CannotWin;
    public bool isMountainLevel;
	public bool isFactory;
    public bool isPrototype;

    public ChracterController PlayerControl;
	public Charge ChargeScript; 
    public crowSpawner Spawner;
    public GameObject SpawnerObject;

    public float DelayBeforeStartTime;
    public float TotalLevelTime;
    public int Score = 0;

    public bool LevelSelectGateOpen;

    public int CurrentHealth;
    public GameObject HealthObject;
    public Vector2 HealthOjectOnePos;


    //Factory Ints
    public int ClocksBroken;
    public float TimeRemaining;
    public float TimeRemainingStart;

    // Use this for initialization
    void Start () {

        PlayerControl = FindObjectOfType<ChracterController>();
        Spawner = FindObjectOfType<crowSpawner>();
        ScoreUpdate();
        UpdateHealth(); 
		ChargeScript = FindObjectOfType<Charge> (); 
        
        GameObject MemoryObj = GameObject.Find("Memory");
		plusOne.GetComponent<SpriteRenderer> ().enabled = false; 
        
	}
    private void Update()
    {
        if(WireOneObject.GetComponent<Wires>().canWin == true && WireTwoObject.GetComponent<Wires>().canWin == true && WireThreeObject.GetComponent<Wires>().canWin == true && WireFourObject.GetComponent<Wires>().canWin == true)
        {
            Debug.Log("Done");
            
            if (FindBirds() == false && CannotWin == false)
            {
                WinLevel();
            }

        }
        //TimeRemaining -= Time.timeSinceLevelLoad*Time.deltaTime;
        TimeRemaining = TimeRemainingStart-Time.timeSinceLevelLoad;
        TimeRemainingUI.GetComponent<Text>().text = (" "+ Mathf.Round(TimeRemaining)+" ");
        ClocksBrokenUI.GetComponent<Text>().text = (" "+ClocksBroken+" "); 
    }

    public void ScoreUpdate()
    {
        //GUI.Label(new Rect(10,10,200,90), "Birds Zapped: " + Score);
        ScoreUI.GetComponent<Text>().text = (" "+Score+" ");   
		StartCoroutine (pickUpClockTime ()); 
    }
    
    public void RestartLevel()
    {
        if (LevelSelectGateOpen)
        {
            Flowchart.BroadcastFungusMessage ("Load level select");
        }
        //stop the spawner and player
        SpawnerObject.SetActive(false);
        PlayerControl.enabled = false;
        //list all game objects to be destroyed
        List<GameObject> DeleteGameObjects = new List<GameObject>();
       
       
            foreach (GameObject deleteGameObject in GameObject.FindGameObjectsWithTag("charge"))
            {
                
				deleteGameObject.GetComponent<Charge> ().StopAllCoroutines (); 
				deleteGameObject.GetComponent<Charge> ().SetFalse (); 
				DeleteGameObjects.Add(deleteGameObject);

            }
            foreach (GameObject deleteGameObject in GameObject.FindGameObjectsWithTag("Target"))
        { 
            if (WireOneObject.GetComponent<Wires>().canWin == true && WireTwoObject.GetComponent<Wires>().canWin == true && WireThreeObject.GetComponent<Wires>().canWin == true && WireFourObject.GetComponent<Wires>().canWin == true)
            {
                deleteGameObject.GetComponent<crowMove>().MakeCrowDisapear(5);
            }
            else
            {
                DeleteGameObjects.Add(deleteGameObject);
            }
        }
            // delete all clone game objects
          
        foreach (GameObject deleteThis in DeleteGameObjects)
            {
//            if()
                Destroy(deleteThis);
	
            }
        
        
        foreach(GameObject x in Spawner.enemies)
        {
            x.GetComponent<crowMove>().ChancetoSpawnCurrent = x.GetComponent<crowMove>().ChancetoSpawnStart;
        }
        //reset players position and health
        // PlayerControl.Start();


        UpdateHealth();
        if(isMountainLevel == true && PlayerObject.transform.position.y >= PlayerObject.GetComponent<ChracterController>().PlayerCurrentWire.GetComponent<Wires>().StartPositionBottom + (Camera.main.orthographicSize / 2))
        {
			//call a coroutine that has yield wait for seconds then put this in it 

			PlayerObject.GetComponent<ChracterController> ().mt_fall ();  
			StartCoroutine (mtFailState ()); 
        }

        
        //reset the delay before play timer
		if (isMountainLevel) {
			Spawner.DelayBeforeStart = DelayBeforeStartTime + Time.time + 1;
		} else {
			Spawner.DelayBeforeStart = DelayBeforeStartTime + Time.time - 1;
		}
        Spawner.StoreAddedTime = 0;
        Spawner.spawnRate = Spawner.spawnRateMin;
        Spawner.TimeSinceFailLevels = 1;
        Spawner.validChoices.Clear();
        Spawner.validChoices.Add(1);
        Spawner.validChoices.Add(2);
        Spawner.validChoices.Add(3);
        Spawner.validChoices.Add(4);

        //(for now reset level timer will change once we have a VO)
        PlayerControl.enabled = true;
        Spawner.enabled = true;
        SpawnerObject.SetActive(true);
        //Score = 0;
    }
    public void WinLevel()
    {
        //grab score
        //freeze spawning, arcade/coreography
        //freeze movment
        SpawnerObject.SetActive(false);
        ////Freeze Time?
        //load the win screen overlay
        //track previous wins, losses?
        GameObject.Find("Memory").GetComponent<Memory>().StoreMemory(RoundNum, true);
        //each round needs a unique value
        SceneManager.LoadScene("GameOver+Win");
    }
    void LoseLevel()
    {
        //grab score
        //freeze spawning, arcade/coreography
        //freeze movment
        SpawnerObject.SetActive(false);
        ////Freeze Time?
        //load the lose screen overlay
        //track previous wins, losses?
        //MemoryObj.GetComponent<Memory>().StoreMemory(RoundNum, false);
        GameObject.Find("Memory").GetComponent<Memory>().StoreMemory(RoundNum, false);
        //each round needs a unique value
        SceneManager.LoadScene("GameOver+Lose");
    }
    public void UpdateHealth()
    {
        // clear all health objects
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("Health"))
        {
            Destroy(x);
        }
        //instantiate in new health objects
        int CurrentHealthStore = new int();
        int CurrentHealthNum = new int();
        Vector2 CurrentHealthPosStore = new Vector2();
        CurrentHealthStore = CurrentHealth;

        while (CurrentHealthStore > 0)
        {
            CurrentHealthPosStore.x= HealthOjectOnePos.x + CurrentHealthNum;
            CurrentHealthPosStore.y = HealthOjectOnePos.y;
            Instantiate(HealthObject, (CurrentHealthPosStore), Quaternion.identity);
            CurrentHealthNum++;
            CurrentHealthStore--;
        }
        if (CurrentHealth == 0 && CannotLose == false && isFactory == false)
        {
            LoseLevel();
        }
    }
    public bool FindBirds()
    {
        List<GameObject> oldTargets = new List<GameObject>();
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("Target"))
        {
            oldTargets.Add(x);
        }
        if (oldTargets.Count == 0)
        {
            return false;
        }
        else { return true; }
    }
    
    
    // FUN FUNGUS FUNCTIONS

    public void OpenFailGate()
    {
        // on end of last VO run this function
        // On next restart, load the level select instead of resetting
        LevelSelectGateOpen = true;
    }


	//PICKING UP CLOCKS 

	public void pickUpClock () {


		StartCoroutine (pickUpClockTime ()); 

	}

	IEnumerator mtFailState () {

		PlayerObject.GetComponent<ChracterController> ().canInput = false; 
		yield return new WaitForSeconds(2f); 
		PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY = PlayerObject.transform.position.y - (Camera.main.orthographicSize / 2);
		PlayerControl.mt_normal (); 
		PlayerObject.GetComponent<ChracterController>().IsinStartPosition = false;
		PlayerObject.GetComponent<ChracterController> ().canInput = true;
	}

	public IEnumerator pickUpClockTime () {


		plusOne.GetComponent<SpriteRenderer>().enabled = true; 
		yield return new WaitForSeconds (.2f);
		plusOne.GetComponent<SpriteRenderer>().enabled = false; 
		yield return new WaitForSeconds (.2f);
		plusOne.GetComponent<SpriteRenderer>().enabled = true; 
		yield return new WaitForSeconds (.2f); 
		plusOne.GetComponent<SpriteRenderer>().enabled = false; 


	}
    
}
