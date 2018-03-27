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

	public GameObject wire1;
	public GameObject wire2;
	public GameObject wire3;
	public GameObject wire4; 


	// Use this for initialization
	void Start () {

		SC = FindObjectOfType<SceneController>();
		AM = FindObjectOfType<AudioManager>();
		player = GameObject.FindWithTag ("Player"); 
		fusebox1 = GameObject.Find ("fusebox"); 

		wire1 = GameObject.Find ("Wire_1"); 
		wire2 = GameObject.Find ("Wire_2"); 
		wire3 = GameObject.Find ("Wire_3"); 
		wire4 = GameObject.Find ("Wire_4"); 
	
		 
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
                if (ChargesCurrentWire = SC.PlayerObject.GetComponent<ChracterController>().PlayerCurrentWire)
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
			}
		}

		if (SC.WireTwoObject != null) {	
			if (ChargesCurrentWire == SC.WireTwoObject) {
				wire2.GetComponent<Wires> ().wire_2_zap (); 
			}
		}

		if (SC.WireThreeObject != null) {
			if (ChargesCurrentWire == SC.WireThreeObject) {
				wire3.GetComponent<Wires> ().wire_3_zap (); 
			}
		}

		if (SC.WireFourObject != null) {
			if (ChargesCurrentWire == SC.WireFourObject) {
				wire4.GetComponent<Wires> ().wire_4_zap (); 
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
		
		yield return new WaitForSeconds (1.2f); 
		SC.CurrentHealth--;
		SC.RestartLevel();

		player.GetComponent<ChracterController> ().Clyde_normal (); 
		fusebox1.GetComponent<fusebox_script> ().fusebox_normal ();
		wire1.GetComponent<Wires> ().wire_1_normal (); 
		wire2.GetComponent<Wires> ().wire_2_normal (); 
		wire3.GetComponent<Wires> ().wire_3_normal (); 
		wire4.GetComponent<Wires> ().wire_4_normal (); 
	

	}

}
