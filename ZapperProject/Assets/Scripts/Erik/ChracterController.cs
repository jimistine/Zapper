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
    public float PlayerHorizontalSpeed = 1;
    public int CurrentWirePositionY;

    int MaxWirePosition = 4;//May need to change max and min wires depending on chages to be implemented
    int MinWirePosition = 1;

    public GameObject PlayerCurrentWire;
    public GameObject ChargeObjects;

    public bool CanShoot = true;
    public float ChargingAmount;
    public float ChargingSpeed = 1;
    public int ChargingLimit = 100;

    public float playerY;
    public float playerX;
    
    public void Start () {

        SC = FindObjectOfType<SceneController>();
        AM = FindObjectOfType<AudioManager>();
        
        CurrentWirePositionY = 1;
        ChangeWire();

        if (SC.WireOneObject.GetComponent<Wires>().PlayerStartRight == true)
        {
			transform.position = new Vector3(5.5f, SC.WireOneObject.transform.position.y + 0.5f);
        }
		else { transform.position = new Vector3(-5.5f, SC.WireOneObject.transform.position.y + 0.5f); }

	}
    void FindCurrentWire()
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
    void ChangeWire()
    {
        FindCurrentWire();
        Wires currentWireScrpt = PlayerCurrentWire.GetComponent<Wires>();
        transform.position = new Vector3(currentWireScrpt.PlayersStartPositionX, currentWireScrpt.PlayersStartPositionY);
    }
    void CreateChargeObject()
    {
        GameObject NewChargeObject = Instantiate(ChargeObjects,new Vector3(transform.position.x, transform.position.y+PlayerCurrentWire.GetComponent<Wires>().ChargesPositionOffsetY, 0), Quaternion.identity ) as GameObject;
        Charge NewChargeScrpt = NewChargeObject.GetComponent<Charge>();
        NewChargeScrpt.ChargesCurrentWire = PlayerCurrentWire;
    }

    // Update is called once per frame
    void Update () {

        playerX = gameObject.transform.position.x;
        playerY = gameObject.transform.position.y;
        
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
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < PlayerCurrentWire.GetComponent<Wires>().AnchorRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * PlayerHorizontalSpeed);
            CanShoot = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow))
        {
            CanShoot = true;
        }
        if (CanShoot == false)
        {
            ChargingAmount = 0;
        }
        if (Input.GetKey(KeyCode.Space)&& CanShoot == true)
        {
            ChangeWire();

            if (ChargingAmount < ChargingLimit)
            {
                ChargingAmount += ChargingSpeed*Time.deltaTime;
            }
            //instantiate a "Charge" object, Should it take  apress and hold?
        }
        if (Input.GetKeyUp(KeyCode.Space) && CanShoot == true)
        {
            Debug.Log("Charged to"+ChargingAmount);

            if (ChargingAmount >= ChargingLimit)
            {
                //release the charge to move, wont move if not charged, cancle charge if move
                Debug.Log("Fire Charge");
                ChargingAmount = 0;
                AM.ShootCharge_source.PlayOneShot(AM.ShootCharge);
                CreateChargeObject();
            }
        }
    }


}
