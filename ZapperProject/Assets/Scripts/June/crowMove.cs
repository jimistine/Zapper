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
	public float ChancetoSpawnCurrent = 0f;
	public float ChancetoSpawnStart = 1f;
	float pauseTime;
	public float stopSpeed = 0; 
	float goSpeed; 
	int randomTimeUntilPause;
	public int randomTimeUntilPauseMax;
	public int randomTimeUntilPauseMin;
	public int ScoreForBird;
	public bool CanReflectCharge = false;
	public Animator anim; 
	private BoxCollider2D boxCol;

    public bool isBird;
    public bool isClock;
    public bool isRock;


	// Use this for initialization
	void Start () {

		ChancetoSpawnCurrent = ChancetoSpawnStart;
		StartCoroutine(wait());
		SC = FindObjectOfType<SceneController>();
		anim = GetComponent<Animator> (); 
		boxCol = GetComponent<BoxCollider2D> (); 

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

        if (isBird == true || isClock)
        {
            transform.Translate(goSpeed, 0, 0);

            if (transform.position.x < CurrentWire.GetComponent<Wires>().AnchorLeft || transform.position.x > CurrentWire.GetComponent<Wires>().AnchorRight)
            {
                FailStateCrow();
                //Destroy bird for now will need a fail state animation for birds hittitng fuze box
                Destroy(gameObject);
            }
        }
        if (isRock == true)
        {
            transform.Translate(0, -goSpeed, 0);
            if (transform.position.y < SC.PlayerObject.transform.position.y + 0.3f && transform.position.y > SC.PlayerObject.transform.position.y - 0.3f && CurrentWire == SC.PlayerObject.GetComponent<ChracterController>().PlayerCurrentWire)
            {
                Debug.Log("That");
                FailStateCrow();
                //Destroy bird for now will need a fail state animation for birds hittitng fuze box
                Destroy(gameObject);
            }
            if (transform.position.y < SC.PlayerObject.transform.position.y - (1.5*Camera.main.orthographicSize))
            {
                Destroy(gameObject);
            }
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

	public void FailStateCrow()

	{
		Debug.Log("Crows fail state");
        SC.CurrentHealth--;
		if (isClock)
		{
			SC.ClocksBroken++;
		}
		SC.RestartLevel();
	}

	public void CrowZap() {

		boxCol.enabled = false;
        goSpeed = 0;
		anim.SetBool ("Zap_Bool", true); 
		StartCoroutine (ZapAnim()); 

	}

	IEnumerator ZapAnim() {

		yield return new WaitForSeconds (.1f); 
		Debug.Log ("zapped!"); 
		yield return new WaitForSeconds (.4f); 
		Destroy (this.gameObject); 
		yield return null; 

	}
    public void MakeCrowDisapear(float x){
        crowSpeed = 0;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DestroyinDelay(x));
    }
    IEnumerator DestroyinDelay(float x){
        yield return new WaitForSeconds(x);
        Destroy(gameObject);

    }






}