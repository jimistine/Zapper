using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
    // find and store the four wires positions, (Y) 
    // Use wire positions to controll player Movment (Y)
    // Use wire positions to inform bird spawns

    public GameObject WireOneObject;
    public GameObject WireTwoObject;
    public GameObject WireThreeObject;
    public GameObject WireFourObject;
    public GameObject PlayerObject;

    public GameObject ScoreUI;

    public ChracterController PlayerControl;
    public crowSpawner Spawner;

    public float DelayBeforeStartTime;
    public float TotalLevelTime;

    public int Score;


    // Use this for initialization
    void Start () {

        PlayerControl = FindObjectOfType<ChracterController>();
        Spawner = FindObjectOfType<crowSpawner>();
        ScoreUpdate();
	}
	
    public void ScoreUpdate()
    {
        //GUI.Label(new Rect(10,10,200,90), "Birds Zapped: " + Score);
        ScoreUI.GetComponent<Text>().text = ("Score "+Score);
    }
    
    public void RestartLevel()
    {
        //stop the spawner and player
        Spawner.enabled = false;
        PlayerControl.enabled = false;
        //list all game objects to be destroyed
        List<GameObject> DeleteGameObjects = new List<GameObject>();

        foreach(GameObject deleteGameObject in GameObject.FindGameObjectsWithTag("charge"))
        {
            DeleteGameObjects.Add(deleteGameObject);
        }
        foreach (GameObject deleteGameObject in GameObject.FindGameObjectsWithTag("Target"))
        {
            DeleteGameObjects.Add(deleteGameObject);
        }
        // delete all clone game objects
        foreach (GameObject deleteThis in DeleteGameObjects)
        {
            Destroy(deleteThis);
        }
        //reset players position
        PlayerControl.Start();
        //reset the delay before play timer
        Spawner.DelayBeforeStart = DelayBeforeStartTime + Time.time - 1;
        Spawner.StoreAddedTime = 0;
        Spawner.spawnRate = Spawner.spawnRateMin;
        Spawner.TimeSinceFailLevels = 1;

        //(for now reset level timer will change once we have a VO)
        PlayerControl.enabled = true;
        Spawner.enabled = true;
        //Score = 0;
    }
}
