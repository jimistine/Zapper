using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour {

	public SceneController SC;
	public AudioManager AM;
	public float ChargeMoveSpeed = 1;
	public bool isReturningCharge = false;
	public GameObject ChargesCurrentWire;
	bool hasTriggered = false; 

	public Sprite new_Sprite; 

	public GameObject player;  

	public GameObject fusebox1; 
	public GameObject fusebox2; 
	public GameObject fusebox3; 
	public GameObject fusebox4; 

	public GameObject alarm1;
	public GameObject alarm2;
	public GameObject alarm3; 
	public GameObject alarm4; 

	public GameObject wire1;
	public GameObject wire2;
	public GameObject wire3;
	public GameObject wire4; 


	// Use this for initialization
	void Start () {

		SC = FindObjectOfType<SceneController>();
		AM = FindObjectOfType<AudioManager>();
		player = GameObject.FindWithTag ("Player"); 

		wire1 = GameObject.Find ("Wire_1"); 
		wire2 = GameObject.Find ("Wire_2"); 
		wire3 = GameObject.Find ("Wire_3"); 
		wire4 = GameObject.Find ("Wire_4"); 

		fusebox1 = GameObject.Find ("fusebox"); 
		fusebox2 = GameObject.Find ("fusebox 2"); 
		fusebox3 = GameObject.Find ("fusebox 3"); 
		fusebox4 = GameObject.Find ("fusebox 4"); 

		alarm1 = GameObject.Find ("alarm"); 
		alarm2 = GameObject.Find ("alarm 2"); 
		alarm3 = GameObject.Find ("alarm 3"); 
		alarm4 = GameObject.Find ("alarm 4"); 
	
		 
	}

	// Update is called once per frame
	void Update ()
	{
        if (SC.isMountainLevel == false)
        {
            if (isReturningCharge == true)
            {
                if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == true)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * (ChargeMoveSpeed / 3));
                }
                if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == false)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * (ChargeMoveSpeed / 3));
                }
                //
                if (ChargesCurrentWire == SC.PlayerObject.GetComponent<ChracterController>().PlayerCurrentWire)
                {
                    if (gameObject.transform.position.x < (SC.PlayerObject.transform.position.x) + 0.2f && gameObject.transform.position.x > (SC.PlayerObject.transform.position.x) - 0.2f)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            if (isReturningCharge == false)
            {
                if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == true)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * ChargeMoveSpeed);
                }
                if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == false)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * ChargeMoveSpeed);
                }
            }
            if (transform.position.x > ChargesCurrentWire.GetComponent<Wires>().AnchorRight + 0.5f || transform.position.x < ChargesCurrentWire.GetComponent<Wires>().AnchorLeft - 0.5f)
            {
                gameObject.GetComponent<Charge>().ChargeFailState();
            }
        }
        if (SC.isMountainLevel == true)
        {
            if (isReturningCharge == true)
            {
                transform.Translate(Vector3.down * Time.deltaTime * (ChargeMoveSpeed / 3));
               if (transform.position.y < ChargesCurrentWire.GetComponent<Wires>().StartPositionBottom)
                {
                    Destroy(gameObject);
                }
            }
            if (isReturningCharge == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * ChargeMoveSpeed);
            }
            // does it matter if charge goes off screen?

            if (transform.position.y > ChargesCurrentWire.GetComponent<Wires>().WirePositionTop)
            {
                gameObject.GetComponent<Charge>().ChargeFailState();
            }
        }
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (hasTriggered == false)
		{
			Debug.Log("collision");

			if (collision.gameObject.tag == "Target" && isReturningCharge == false)
			{
				if (collision.gameObject.GetComponent<crowMove>().CanReflectCharge == true)
				{
					isReturningCharge = true;
					ChangeSprite (); 
				}
				else
				{
					AM.Hit_source.PlayOneShot(AM.Hit);
					AM.Hit_source.PlayOneShot(AM.Hit);

                    Destroy(gameObject);
                }
                //currently destroying birds on collisions may need to run a function for them to leave scene or some other score behaviours

                SC.Score += collision.gameObject.GetComponent<crowMove>().ScoreForBird;
				SC.ScoreUpdate();
             
				if (collision.gameObject.GetComponent<crowMove>().isBird)
                {
                    collision.gameObject.GetComponent<crowMove>().CrowZap();  //run the function on the crowScript 

                }

              	//Destroy(collision.gameObject);
                AM.Hit_source.PlayOneShot(AM.Hit);
				SC.Score++;
			}

			else if (isReturningCharge == true && collision.gameObject.tag == "Player")

			{
                if (SC.isMountainLevel == false)
                {
                    // destroy returinging charge on collision with player, may have to change function depending on hwo we want return charges to behave.
                    hasTriggered = true;
                    AM.Hit_source.PlayOneShot(AM.Hit);
                    //SC.Score++;
                    //SC.ScoreUpdate();
                    Destroy(gameObject);
                    AM.Hit_source.PlayOneShot(AM.Hit);
                }
                if (SC.isMountainLevel == true)
                {
                    hasTriggered = true;
                    //cause player to fall a specific distance downwards, not below bottom of wire.
                    collision.GetComponent<ChracterController>().isFalling = true;
                }
				
			}
		}
	}

	public void ChargeFailState()

	{
		Debug.Log("Charge Fail State");
		Debug.Log (ChargesCurrentWire); 
		AM.FailSound_source.PlayOneShot(AM.Fail);
        //destroy for now will have to change things depeneding on how we record fail states

		//fusebox1.GetComponent<fusebox_script> ().fusebox_zap ();

		if (SC.WireOneObject != null) {
			if (ChargesCurrentWire == SC.WireOneObject) { 
				wire1.GetComponent<Wires> ().wire_1_zap (); 
				if (SC.isFactory) {
					Debug.Log ("alarm 1 rang!");
					alarm1.GetComponent<alarmScript> ().alarm_zap (); 
				} else {
					fusebox1.GetComponent<fusebox_script> ().fusebox_zap (); 
				}
			}
		}

		if (SC.WireTwoObject != null) {	
			if (ChargesCurrentWire == SC.WireTwoObject) {
				wire2.GetComponent<Wires> ().wire_2_zap (); 
				if (SC.isFactory) {
					Debug.Log ("alarm 2 rang!"); 
					alarm2.GetComponent<alarmScript> ().alarm_zap_2 ();
				} else {
					fusebox2.GetComponent<fusebox_script> ().fusebox_zap_2 ();
				}
			}
		}

		if (SC.WireThreeObject != null) {
			if (ChargesCurrentWire == SC.WireThreeObject) {
				wire3.GetComponent<Wires> ().wire_3_zap (); 
				if (SC.isFactory) {
					alarm3.GetComponent<alarmScript> ().alarm_zap_3 (); 
				} else {
					fusebox3.GetComponent<fusebox_script> ().fusebox_zap_3 (); 
				}
			}
		}

		if (SC.WireFourObject != null) {
			if (ChargesCurrentWire == SC.WireFourObject) {
				wire4.GetComponent<Wires> ().wire_4_zap (); 
				if (SC.isFactory) {
					alarm4.GetComponent<alarmScript> ().alarm_zap_4 (); 
				} else {
					fusebox4.GetComponent<fusebox_script> ().fusebox_zap_4 (); 
				}
			}
		}

		player.GetComponent<ChracterController> ().Clyde_zap ();

		StartCoroutine (RestartLevel ());  

	}

	public void ChangeSprite() {

		this.GetComponent<SpriteRenderer>().sprite = new_Sprite;
	}

	IEnumerator WaitForDestruction () {

		yield return new WaitForSeconds (1f); 

	}

	IEnumerator RestartLevel () { 

		Debug.Log ("charge reset beginning"); 
		yield return new WaitForSeconds (1.2f); 
		SC.CurrentHealth--;
		SC.RestartLevel();


		//set animation states back to normal 
		player.GetComponent<ChracterController> ().Clyde_normal (); 

		wire1.GetComponent<Wires> ().wire_1_normal (); 
		wire2.GetComponent<Wires> ().wire_2_normal (); 
		wire3.GetComponent<Wires> ().wire_3_normal (); 
		wire4.GetComponent<Wires> ().wire_4_normal (); 

//		if (SC.isFactory) {
//
//			alarm1.GetComponent<alarmScript> ().alarm_normal (); 
//			alarm2.GetComponent<alarmScript> ().alarm_normal_2 (); 
//			alarm3.GetComponent<alarmScript> ().alarm_normal_3 (); 
//			alarm4.GetComponent<alarmScript> ().alarm_normal_4 (); 
//			Debug.Log ("charge reset end"); 
//
//		} else {
//
//			fusebox1.GetComponent<fusebox_script> ().fusebox_normal ();
//			fusebox2.GetComponent<fusebox_script> ().fusebox_normal_2 ();
//			fusebox3.GetComponent<fusebox_script> ().fusebox_normal_3 (); 
//			fusebox4.GetComponent<fusebox_script> ().fusebox_normal_4 (); 
//			Debug.Log ("charge reset end"); 
//
//		}


	

	}

	public void SetFalse () {



		if (SC.isFactory) {

			alarm1.GetComponent<alarmScript> ().alarm_normal (); 
			alarm2.GetComponent<alarmScript> ().alarm_normal_2 (); 
			alarm3.GetComponent<alarmScript> ().alarm_normal_3 (); 
			alarm4.GetComponent<alarmScript> ().alarm_normal_4 (); 
			Debug.Log ("charge reset end"); 

		} else {

			fusebox1.GetComponent<fusebox_script> ().fusebox_normal ();
			fusebox2.GetComponent<fusebox_script> ().fusebox_normal_2 ();

			if (fusebox3 != null) {
				fusebox3.GetComponent<fusebox_script> ().fusebox_normal_3 (); 
			}

			if (fusebox4 != null) {
				fusebox4.GetComponent<fusebox_script> ().fusebox_normal_4 (); 
			}

			Debug.Log ("charge reset end"); 

		}


	}

}
