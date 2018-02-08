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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");

        if (collision.gameObject.tag == "Target" && isReturningCharge == false)
        {
            if (collision.gameObject.GetComponent<crowMove>().CanReflectCharge == true)
            {
                isReturningCharge = true;
            }else { Destroy(gameObject); }
            //currently destroying birds on collisions may need to run a function for them to leave scene or some other score behaviours
            Destroy(collision.gameObject);
        }
        else if(isReturningCharge == true && collision.gameObject.tag == "Player")
        {
            // destroy returinging charge on collision with player, may have to change function depending on hwo we want return charges to behave.
            Destroy(gameObject);
        }
    }
    public void ChargeFailState()
    {
        Debug.Log("Charge Fail State");
        //destroy for now will have to change things depeneding on how we record fail states
        Destroy(gameObject);
    }
}
