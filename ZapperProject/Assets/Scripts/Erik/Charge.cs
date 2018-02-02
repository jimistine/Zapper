using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour {

    
    public float ChargeMoveSpeed = 1;
    public bool isReturningCharge = false;
    public GameObject ChargesCurrentWire;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (isReturningCharge == true)
        {
            if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == true)
            {
                transform.Translate(Vector3.right * Time.deltaTime * ChargeMoveSpeed);
            }
            if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * ChargeMoveSpeed);
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
        

        if (transform.position.x > ChargesCurrentWire.GetComponent<Wires>().AnchorRight || transform.position.x < ChargesCurrentWire.GetComponent<Wires>().AnchorLeft)
        {
            ChargeFailState();
        }
    }
    public void ChargeFailState()
    {
        Debug.Log("Charge Fail State");
        //destroy for now will have to change things depeneding on hwo we record fail states
        Destroy(gameObject);
    }
}
