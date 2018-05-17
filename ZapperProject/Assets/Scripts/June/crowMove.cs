using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class crowMove : MonoBehaviour {
	public SceneController SC;
	public AudioManager AM;
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
	public bool hasplayedPlayerDeathOnce = false;


	// Use this for initialization
	//comment to see the changes!
	void Start () {

		ChancetoSpawnCurrent = ChancetoSpawnStart;
		StartCoroutine(wait());
		SC = FindObjectOfType<SceneController>();
		AM = FindObjectOfType<AudioManager>();
		anim = GetComponent<Animator> (); 
		boxCol = GetComponent<BoxCollider2D> ();
		hasplayedPlayerDeathOnce = false;

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {


			anim.SetBool ("Zap_Bool", true); 

		}
			
		randomTimeUntilPause = Random.Range (randomTimeUntilPauseMin, randomTimeUntilPauseMax); 
		pauseTime = Random.Range (pauseTimeMin, pauseTimeMax);

		if(CurrentWire.GetComponent<Wires>().PlayerStartRight == false)
		{
			goSpeed = crowSpeed * (-1);
			//flip prefab
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
		}

        if (isBird == true || isClock == true)
        {
            transform.Translate(goSpeed, 0, 0);

            if (transform.position.x < CurrentWire.GetComponent<Wires>().AnchorLeft || transform.position.x > CurrentWire.GetComponent<Wires>().AnchorRight)
            {
                FailStateCrow();
                //Destroy bird for now will need a fail state animation for birds hittitng fuze box
                //Destroy(gameObject);
            }
        }
        if (isRock == true)
        {
            transform.Translate(0, -goSpeed, 0);
            if (transform.position.y < SC.PlayerObject.transform.position.y + 1.0f && transform.position.y > SC.PlayerObject.transform.position.y - 1.0f && CurrentWire == SC.PlayerObject.GetComponent<ChracterController>().PlayerCurrentWire)
            {
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
        crowSpeed = 0;
		Debug.Log("Crows fail state 1");
        SC.CurrentHealth--;
		if (SC.isMountainLevel)
		{
			AM.PlayerDeath_source.PlayOneShot(AM.PlayerDeath);
		}
		if (isClock == true)
		{
			//SC.ClocksBroken++;
            goSpeed = 0;
			StartCoroutine (clockDestructionWait ()); 
		}
        else
        {
            SC.RestartLevel();

        }
        Debug.Log ("fail state crow 2"); 
	}

	public void CrowZap() {

		boxCol.enabled = false;
        goSpeed = 0;
		anim.SetBool ("Zap_Bool", true); 
		StartCoroutine (ZapAnim()); 

	}

	IEnumerator clockDestructionWait () {

        Debug.Log ("started enum"); 
		anim.SetBool ("Zap_Bool", true); 
		PlayPlayerDeathOnce();
		yield return new WaitForSeconds (1.2f); 
		SC.ClocksBroken++;
		SC.RestartLevel (); 

	}

	public void PlayPlayerDeathOnce()
	{
		if (hasplayedPlayerDeathOnce == false)
		{
			AM.PlayerDeath_source.PlayOneShot(AM.PlayerDeath);
			hasplayedPlayerDeathOnce = true;
		}
	}

	IEnumerator ZapAnim() {

		yield return new WaitForSeconds (.1f); 
		Debug.Log ("zapped!"); 
		yield return new WaitForSeconds (.4f); 
		Destroy (this.gameObject); 
		yield return null; 

	}
    public void MakeCrowDisapear(float x){
        goSpeed = 0;

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DestroyinDelay(x));
    }
    IEnumerator DestroyinDelay(float x){
        yield return new WaitForSeconds(x);
        Destroy(gameObject);

    }






}