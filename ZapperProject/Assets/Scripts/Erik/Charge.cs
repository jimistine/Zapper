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

	public GameObject platform1; 
	public GameObject platform2; 
	public GameObject platform3; 
	public GameObject platform4; 

//	public GameObject falling1; 
//	public GameObject falling2; 
//	public GameObject falling3; 
//	public GameObject falling4; 

	bool HasCalledFailFunction; 

	public Animator anim;

	public List<GameObject> HitUnits;


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

		platform1 = GameObject.Find ("platform 1"); 
		platform2 = GameObject.Find ("platform 2"); 
		platform3 = GameObject.Find ("platform 3"); 
		platform4 = GameObject.Find ("platform 4"); 

//		falling1 = GameObject.Find ("falling1"); 
//		falling2 = GameObject.Find ("falling2"); 
//		falling3 = GameObject.Find ("falling3"); 
//		falling4 = GameObject.Find ("falling4"); 

	
		anim = GetComponent<Animator> (); 
		 
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
                    transform.Translate(Vector3.right * Time.deltaTime * (ChargeMoveSpeed / 5));
                }
                if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == false)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * (ChargeMoveSpeed / 5));
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
			if (transform.position.x > ChargesCurrentWire.GetComponent<Wires>().AnchorRight + 0.5f || transform.position.x < ChargesCurrentWire.GetComponent<Wires>().AnchorLeft - 0.5f && HasCalledFailFunction == false)
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
                //gameObject.GetComponent<Charge>().ChargeFailState();
            }
        }
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (hasTriggered == false)
		{
			if (SC.isPrototype && collision.gameObject.tag== "Target")
			{
				
				HitUnits.Add(collision.gameObject);
				if (HitUnits.Count == 1)
				{
					Destroy(collision.gameObject);
					Destroy(gameObject);
				}
				else if (HitUnits.Count > 1)
				{
					Destroy(HitUnits[0]);
					Destroy(gameObject);
				}
			}

			if (collision.gameObject.tag == "Target" && isReturningCharge == false)
			{
				if (collision.gameObject.GetComponent<crowMove>().CanReflectCharge == true)
				{
					isReturningCharge = true;

					if (collision.gameObject.GetComponent<crowMove>().isClock)
					{
						ChangeSprite();

					}

					if (collision.gameObject.GetComponent<crowMove>().isRock)
					{

						AM.Hit_source.PlayOneShot(AM.Hit);
						//Debug.Log("shattered!");
						anim.SetBool("shatter_bool", true);


					}
				}
				else
				{
					if (SC.isPrototype == false)
					{
						AM.Hit_source.PlayOneShot(AM.Hit);
						AM.Hit_source.PlayOneShot(AM.Hit);
					}

					Destroy(gameObject);
				}
                //currently destroying birds on collisions may need to run a function for them to leave scene or some other score behaviours

                if (SC.isFactory == false)
                {
                    SC.Score += collision.gameObject.GetComponent<crowMove>().ScoreForBird;
                    SC.ScoreUpdate();
                }

				if (collision.gameObject.GetComponent<crowMove>().isBird)
				{
					HitUnits.Add(collision.gameObject);

					if (HitUnits.Count == 1)
					{
						collision.gameObject.GetComponent<crowMove>().CrowZap();
						Destroy(gameObject);
					}
					else if (HitUnits.Count > 1)
					{
						HitUnits[0].gameObject.GetComponent<crowMove>().CrowZap();
						HitUnits.Clear();
						Destroy(gameObject);
					}
				}

				if (collision.gameObject.GetComponent<crowMove>().isClock == true ||
				    collision.gameObject.GetComponent<crowMove>().isRock == true)
				{

					Destroy(collision.gameObject);

				}

				AM.Hit_source.PlayOneShot(AM.Hit);
				if (SC.isFactory)
				{

				}
				else
				{
					SC.Score++;
				}

			}

			else if (isReturningCharge == true && collision.gameObject.tag == "Player")

			{
				if (SC.isMountainLevel == false && SC.isFactory == false)
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
					AM.PlayerHit_source.PlayOneShot(AM.PlayerHit);  
					//cause player to fall a specific distance downwards, not below bottom of wire.
					collision.GetComponent<ChracterController>().isFalling = true;
				}

				if (SC.isFactory == true && SC.isMountainLevel == false) { 

					Debug.Log ("Collected clock!"); 
					AM.PlayerHit_source.PlayOneShot(AM.PlayerHit);  
					hasTriggered = true;
					SC.Score++;
					SC.ScoreUpdate();
					Destroy(gameObject);
					


				}

			}
		}
		
	}

	public void ChargeFailState()

	{
		
		Debug.Log("Charge Fail State");
		Debug.Log (ChargesCurrentWire);
		if (SC.isPrototype == false)
		{

			HasCalledFailFunction = true;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			AM.play_fail();
		//AM.FailSound_source.PlayOneShot(AM.Fail);
		//	AM.PlayerDeath_source.PlayOneShot(AM.PlayerDeath);

			//destroy for now will have to change things depeneding on how we record fail states

			//fusebox1.GetComponent<fusebox_script> ().fusebox_zap ();

			if (SC.WireOneObject != null)
			{
				if (ChargesCurrentWire == SC.WireOneObject)
				{

					wire1.GetComponent<Wires>().wire_1_zap();

					if (SC.isFactory == false && SC.isMountainLevel == false) {
						platform1.GetComponent<platformScript> ().platform_zap (); 
						platform2.GetComponent<platformScript> ().platform_zap_2 ();
						if (fusebox3 != null) {
							platform3.GetComponent<platformScript> ().platform_zap_3 (); 
						}

						if (fusebox4 != null) {
							platform4.GetComponent<platformScript> ().platform_zap_4 (); 
						}
					}

					if (SC.isFactory)
					{
						Debug.Log("alarm 1 rang!");
						alarm1.GetComponent<alarmScript>().alarm_zap();
					}
					else if (SC.isPrototype == false)
					{
						fusebox1.GetComponent<fusebox_script>().fusebox_zap();
					}
					else
					{
						return;
					}
				}
			}

			if (SC.WireTwoObject != null)
			{
				if (ChargesCurrentWire == SC.WireTwoObject)
				{

					wire2.GetComponent<Wires>().wire_2_zap();

					if (SC.isFactory == false && SC.isMountainLevel == false) {
						platform1.GetComponent<platformScript> ().platform_zap (); 
						platform2.GetComponent<platformScript> ().platform_zap_2 ();
						if (fusebox3 != null) {
							platform3.GetComponent<platformScript> ().platform_zap_3 (); 
						}

						if (fusebox4 != null) {
							platform4.GetComponent<platformScript> ().platform_zap_4 (); 
						}
					}

					if (SC.isFactory)
					{
						Debug.Log("alarm 2 rang!");
						alarm2.GetComponent<alarmScript>().alarm_zap_2();
					}
					else if (SC.isPrototype == false)
					{
						fusebox2.GetComponent<fusebox_script>().fusebox_zap_2();
					}
					else
					{
						return;
					}
				}
			}

			if (SC.WireThreeObject != null)
			{
				if (ChargesCurrentWire == SC.WireThreeObject)
				{

					wire3.GetComponent<Wires>().wire_3_zap();

					if (SC.isFactory == false && SC.isMountainLevel == false) {
						platform1.GetComponent<platformScript> ().platform_zap (); 
						platform2.GetComponent<platformScript> ().platform_zap_2 ();
						if (fusebox3 != null) {
							platform3.GetComponent<platformScript> ().platform_zap_3 (); 
						}

						if (fusebox4 != null) {
							platform4.GetComponent<platformScript> ().platform_zap_4 (); 
						}
					}

					if (SC.isFactory)
					{
						alarm3.GetComponent<alarmScript>().alarm_zap_3();
					}
					else if (SC.isPrototype == false)
					{
						fusebox3.GetComponent<fusebox_script>().fusebox_zap_3();
					}
					else
					{
						return;
					}
				}
			}

			if (SC.WireFourObject != null)
			{
				if (ChargesCurrentWire == SC.WireFourObject)
				{
					wire4.GetComponent<Wires>().wire_4_zap();

					if (SC.isFactory == false && SC.isMountainLevel == false) {
						platform1.GetComponent<platformScript> ().platform_zap (); 
						platform2.GetComponent<platformScript> ().platform_zap_2 ();
						if (fusebox3 != null) {
							platform3.GetComponent<platformScript> ().platform_zap_3 (); 
						}

						if (fusebox4 != null) {
							platform4.GetComponent<platformScript> ().platform_zap_4 (); 
						}
					}

					if (SC.isFactory)
					{
						alarm4.GetComponent<alarmScript>().alarm_zap_4();
					}
					else if (SC.isPrototype == false)
					{
						fusebox4.GetComponent<fusebox_script>().fusebox_zap_4();
					}
					else
					{
						return;
					}
				}
			}

			player.GetComponent<ChracterController>().Clyde_zap();

			StartCoroutine(RestartLevel());
		}
		else{Destroy(gameObject);}
	}

	public void ChangeSprite() {

		this.GetComponent<SpriteRenderer>().sprite = new_Sprite;
		Debug.Log ("changed sprite!"); 
	}

	IEnumerator WaitForDestruction () {

		yield return new WaitForSeconds (1f); 

	}

	IEnumerator RestartLevel () { 

		Debug.Log ("charge reset beginning"); 
		yield return new WaitForSeconds (1.2f);
		//INCREMENT CLOCK BROKEN++ AFTER WAIT FOR SECONDS ANIM
		if (SC.isFactory)
		{
			SC.ClocksBroken++;
		}
		SC.CurrentHealth--;
		//AM.PlayerDeath_source.PlayOneShot(AM.PlayerDeath);
		SC.RestartLevel();


		//set animation states back to normal 
		player.GetComponent<ChracterController> ().Clyde_normal (); 

		wire1.GetComponent<Wires> ().wire_1_normal (); 
		wire2.GetComponent<Wires> ().wire_2_normal ();
		if (wire3 != null)
		{
			wire3.GetComponent<Wires> ().wire_3_normal (); 

		}
		if (wire4 != null)
		{
			wire4.GetComponent<Wires> ().wire_4_normal (); 

		}


	}
		
	public void SetFalse () {

		if (SC.isFactory == true) {
			if (alarm1 != null)
			{
				alarm1.GetComponent<alarmScript> ().alarm_normal (); 
			}
			if (alarm2 != null)
			{
				alarm2.GetComponent<alarmScript> ().alarm_normal_2 (); 
			}
			if (alarm3 != null)
			{
				alarm3.GetComponent<alarmScript> ().alarm_normal_3 (); 
			}
			if (alarm4 != null)
			{
				alarm4.GetComponent<alarmScript> ().alarm_normal_4 (); 
			}
			Debug.Log ("charge reset end"); 

		} else if (SC.isMountainLevel == false && SC.isFactory == false) {

			fusebox1.GetComponent<fusebox_script> ().fusebox_normal ();
			fusebox2.GetComponent<fusebox_script> ().fusebox_normal_2 ();
			platform1.GetComponent<platformScript> ().platform_normal (); 
			platform2.GetComponent <platformScript> ().platform_normal_2 (); 

		}

		if (fusebox3 != null) {

			fusebox3.GetComponent<fusebox_script> ().fusebox_normal_3 (); 
			platform3.GetComponent<platformScript> ().platform_normal_3 (); 

		}

		if (fusebox4 != null) {

			fusebox4.GetComponent<fusebox_script> ().fusebox_normal_4 (); 
			platform4.GetComponent<platformScript> ().platform_normal_4 (); 

		}
	}

}
