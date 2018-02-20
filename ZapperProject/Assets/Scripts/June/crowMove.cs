using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowMove : MonoBehaviour {
    public SceneController SC;
    public GameObject CurrentWire;
	public float crowSpeed; 
	public float startWait; 
	public float pauseTimeMax;
    public float pauseTimeMin;
    public float ChancetoSpawn;
    float pauseTime;
    public float stopSpeed = 0; 
	float goSpeed; 
	int randomTimeUntilPause;
    public int randomTimeUntilPauseMax;
    public int randomTimeUntilPauseMin;
    public int ScoreForBird;
    public bool CanReflectCharge = false;


    // Use this for initialization
    void Start () {

		StartCoroutine (wait());
        SC = FindObjectOfType<SceneController>();
		
	}
	
	// Update is called once per frame
	void Update () {

		randomTimeUntilPause = Random.Range (randomTimeUntilPauseMin, randomTimeUntilPauseMax); 
		pauseTime = Random.Range (pauseTimeMin, pauseTimeMax);

        if(CurrentWire.GetComponent<Wires>().PlayerStartRight == false)
        {
            goSpeed = crowSpeed * (-1);
            //flip prefab
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

		transform.Translate (goSpeed, 0, 0); 

        if (transform.position.x < CurrentWire.GetComponent<Wires>().AnchorLeft || transform.position.x > CurrentWire.GetComponent<Wires>().AnchorRight)
        {
            FailStateCrow();
            //Destory bird for now will need a fail state animation for birds hittitng fuze box
            Destroy(gameObject);
        }
		
	}

	IEnumerator wait () {

		goSpeed = stopSpeed; 
		yield return new WaitForSeconds (1); 
		goSpeed = crowSpeed; 
		StartCoroutine (pause ()); 
	}

	IEnumerator pause() {
	
		yield return new WaitForSeconds (randomTimeUntilPause); 
		goSpeed = 0; 
		yield return new WaitForSeconds (pauseTime); 
		goSpeed = crowSpeed; 
		StartCoroutine (pause ()); 
	}
   
	void FailStateCrow()
    {
        Debug.Log("Crows fail state");
        //SC.RestartLevel();

    }
 


}
