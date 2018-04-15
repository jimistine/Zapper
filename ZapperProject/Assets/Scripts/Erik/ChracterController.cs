using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterController : MonoBehaviour {
	//Allow player to move between wire positions (Y)
	//Allow player to move along wire (X)
	//Allow player to perform action (Instantiate charge)
	//When player collides with return charge destroy
	// Use this for initialization
	public SceneController SC;
	public AudioManager AM;
	public float PlayerHorizontalSpeed = 10;
	public float PlayersStartingPositionY; 
	public int CurrentWirePositionY;
    public int CurrentWirePositionX;

	public int MaxWirePosition = 4;//May need to change max and min wires depending on chages to be implemented
	public int MinWirePosition = 1;

	public GameObject PlayerCurrentWire;
	public GameObject ChargeObjects;
	public GameObject NewChargeObjects;

	public SpriteRenderer mySpriteRenderer; 

	public bool CanShoot = true;
    public bool CanMoveLeftRight = true;
	public bool IsUsingCharge_1 = true;
    public bool isFalling = false;
	public float ChargingAmount;
	public float ChargingSpeed = 1;
	public int ChargingLimit = 100;

	public float playerY;
	public float playerX;

	public static Animator anim;
   public bool IsinStartPosition = false;

	public GameObject wire1;

	public bool canInput = true; 

	public void Start () {

		mySpriteRenderer = gameObject.GetComponent<SpriteRenderer> (); 
		anim = GetComponent<Animator> (); 

		SC = FindObjectOfType<SceneController>();
		AM = FindObjectOfType<AudioManager>();

		CurrentWirePositionY = 1;
        CurrentWirePositionX = 1;
		PlayersStartingPositionY = SC.WireOneObject.GetComponent<Wires>().StartPositionBottom;

		IsUsingCharge_1 = true;

	

	}
 
	public void FindCurrentWire()
	{
        if (SC.isMountainLevel == false)
        {
            if (CurrentWirePositionY == 1)
            {
                PlayerCurrentWire = SC.WireOneObject;
            }
            if (CurrentWirePositionY == 2)
            {
                PlayerCurrentWire = SC.WireTwoObject;
            }
            if (CurrentWirePositionY == 3)
            {
                PlayerCurrentWire = SC.WireThreeObject;
            }
            if (CurrentWirePositionY == 4)
            {
                PlayerCurrentWire = SC.WireFourObject;
            }
        }
        if (SC.isMountainLevel == true)
        {
            if (CurrentWirePositionX == 1)
            {
                PlayerCurrentWire = SC.WireOneObject;
            }
            if (CurrentWirePositionX == 2)
            {
                PlayerCurrentWire = SC.WireTwoObject;
            }
            if (CurrentWirePositionX == 3)
            {
                PlayerCurrentWire = SC.WireThreeObject;
            }
            if (CurrentWirePositionX == 4)
            {
                PlayerCurrentWire = SC.WireFourObject;
            }
        }

    }
	void ChangeWire()
	{
		FindCurrentWire();
		Wires currentWireScrpt = PlayerCurrentWire.GetComponent<Wires>();

        if (SC.isMountainLevel == false)
        {
            transform.position = new Vector3(currentWireScrpt.PlayersStartPositionX, currentWireScrpt.PlayersStartPositionY);
            if (PlayerCurrentWire.GetComponent<Wires>().PlayerStartRight == true)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (PlayerCurrentWire.GetComponent<Wires>().PlayerStartRight == false)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (SC.isMountainLevel == true)
        {
            if (IsinStartPosition == false)
            {
	            transform.position = new Vector3(currentWireScrpt.PlayersStartPositionX, PlayersStartingPositionY); 
            }

            if (IsinStartPosition == true)
            {
                transform.position = new Vector3(currentWireScrpt.PlayersStartPositionX, gameObject.transform.position.y);
            }
            //Debug.Log(new Vector3(currentWireScrpt.PlayersStartPositionX, currentWireScrpt.PlayersStartPositionY));
        }
		
	}
	void CreateChargeObject()
	{
		if (IsUsingCharge_1)
		{
			GameObject NewChargeObject = Instantiate(ChargeObjects,
				new Vector3(transform.position.x,
					transform.position.y + PlayerCurrentWire.GetComponent<Wires>().ChargesPositionOffsetY, 0),
				Quaternion.identity) as GameObject;
			Charge NewChargeScrpt = NewChargeObject.GetComponent<Charge>();
			NewChargeScrpt.ChargesCurrentWire = PlayerCurrentWire;
		}
		if (IsUsingCharge_1 == false)
		{
			GameObject NewChargeObject = Instantiate(NewChargeObjects,
				new Vector3(transform.position.x,
					transform.position.y + PlayerCurrentWire.GetComponent<Wires>().ChargesPositionOffsetY, 0),
				Quaternion.identity) as GameObject;
			Charge NewChargeScrpt = NewChargeObject.GetComponent<Charge>();
			NewChargeScrpt.ChargesCurrentWire = PlayerCurrentWire;
		}
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {

			Debug.Log ("falling!"); 
			anim.SetBool ("Rock_Bool", true); 

		}

        if(IsinStartPosition == false)
        {
            ChangeWire();
            IsinStartPosition = true;
        }

		playerX = gameObject.transform.position.x;
		playerY = gameObject.transform.position.y;

		anim.SetBool ("Run_Bool", false); 
		//		anim.SetBool ("Shoot_Bool", false); 

        if(SC.isMountainLevel == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentWirePositionY < MaxWirePosition)
                {
                    CurrentWirePositionY++;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentWirePositionY == MaxWirePosition)
                {
                    CurrentWirePositionY = MinWirePosition;
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentWirePositionY > MinWirePosition)
                {
                    CurrentWirePositionY--;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentWirePositionY == MinWirePosition)
                {
                    CurrentWirePositionY = MaxWirePosition;
                }
                ChangeWire();
                ChargingAmount = 0;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > PlayerCurrentWire.GetComponent<Wires>().AnchorLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * PlayerHorizontalSpeed);
                CanShoot = false;
				anim.SetBool ("Pickup_Bool", false); 
                anim.SetBool("Run_Bool", true);
            }
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < PlayerCurrentWire.GetComponent<Wires>().AnchorRight)
            {
                transform.Translate(Vector3.right * Time.deltaTime * PlayerHorizontalSpeed);
                CanShoot = false;
                //anim.SetTrigger ("Run_Trigger"); 
				anim.SetBool ("Pickup_Bool", false); 
                anim.SetBool("Run_Bool", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                CanShoot = true;
            }
        }


        else if (SC.isMountainLevel == true && isFalling == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) )
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) && CurrentWirePositionX < MaxWirePosition)
                {
                    CurrentWirePositionX++;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && CurrentWirePositionX == MaxWirePosition)
                {
                    CurrentWirePositionX = MinWirePosition;
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentWirePositionX > MinWirePosition)
                {
                    CurrentWirePositionX--;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentWirePositionX == MinWirePosition)
                {
                    CurrentWirePositionX = MaxWirePosition;
                }
                ChangeWire();
                ChargingAmount = 0;
            }
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > PlayerCurrentWire.GetComponent<Wires>().StartPositionBottom)
            {
                transform.Translate(Vector3.down * Time.deltaTime * PlayerHorizontalSpeed);
                anim.SetBool("Run_Bool", true);
            }
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < PlayerCurrentWire.GetComponent<Wires>().WirePositionTop)
            {
                transform.Translate(Vector3.up * Time.deltaTime * PlayerHorizontalSpeed);
                anim.SetBool("Run_Bool", true);
            }
	        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y >= PlayerCurrentWire.GetComponent<Wires>().WirePositionTop && PlayerCurrentWire.GetComponent<Wires>().isSummitWire == true) 
            {
                //for now when the player reaches the top of the wire, win that level. 
                SC.WinLevel();
            }
        }
		if (Input.GetKey(KeyCode.Space)&& CanShoot == true && Time.timeSinceLevelLoad > 2)
		{
			ChangeWire();

			if (ChargingAmount < ChargingLimit)
			{
				ChargingAmount += ChargingSpeed*Time.deltaTime;
			}

		} //instantiate a "Charge" object
		if (Input.GetKeyUp(KeyCode.Space) && CanShoot == true && Time.timeSinceLevelLoad >2)
		{
			anim.SetBool ("Pickup_Bool", false); 
			anim.SetBool ("Shoot_Bool", true); 
			Debug.Log("Fire Charge");
			ChargingAmount = 0;
			AM.Shoot_source.PlayOneShot(AM.Shoot);
			CreateChargeObject();
			StartCoroutine (Anim_shoot ()); 
			Debug.Log("Charged to"+ChargingAmount);
		}
		if (Input.GetKeyDown (KeyCode.A)) {

			anim.SetBool ("Pickup_Bool", false); 
			anim.SetBool ("Zap_Bool", true); 
		}
		if (isFalling == true || canInput == false)
        
		{
			//flashing the character animation when player is hit 
			this.GetComponent<Flash>().flicker (mySpriteRenderer); 

            if (transform.position.y > PlayerCurrentWire.GetComponent<Wires>().StartPositionBottom)
            {
                transform.Translate(Vector3.down * Time.deltaTime * PlayerHorizontalSpeed);
            }

            CanShoot = false;
           

            // need to decide how long they will fall, distance? time?
        }

		if (isFalling == true) {

			StartCoroutine(Falling());

		}
	}


    IEnumerator Falling()
    {
        yield return new WaitForSeconds(1);
        isFalling = false;
        CanShoot = true;
		mySpriteRenderer.enabled = true; 
    }

	IEnumerator Anim_shoot () {


		yield return new WaitForSeconds (.2f); 
		anim.SetBool ("Shoot_Bool", false); 
		yield return null; 
	}

	public void Clyde_zap () {

		anim.SetBool ("Zap_Bool", true); 
	}

	public void Clyde_normal () {

		anim.SetBool ("Zap_Bool", false); 
	}

	public void mt_fall () {
		
		anim.SetBool ("Rock_Bool", true); 

	}

	public void mt_normal () {

		anim.SetBool ("Rock_Bool", false); 

	}

	//Called by Fungus to expand/reduce player movement on the fly
	public void set_max_pos_4()
	{
		MaxWirePosition = 4;
	}
	public void set_max_pos_2()
	{
		MaxWirePosition = 2;
	}
	//Called by Fungus to move player at will
	public void set_player_pos_1()
	{
		PlayerCurrentWire = wire1;
		ChangeWire();
	}
	// Called by fungus to disable player shooting
	public void disable_player_shoot()
	{
		CanShoot = false;
	}
	// Called by fungus to enable player shooting
	public void enable_player_shoot()
	{
		CanShoot = true;
	}

	public void Swap_Player_Charge()
	{
		IsUsingCharge_1 = false;
	}
}



