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



    // Use this for initialization
    void Start () {

        SC = FindObjectOfType<SceneController>();
        AM = FindObjectOfType<AudioManager>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (isReturningCharge == true)
        {
            if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == true)
            {
                transform.Translate(Vector3.right * Time.deltaTime * (ChargeMoveSpeed/3));
            }
            if (ChargesCurrentWire.GetComponent<Wires>().PlayerStartRight == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (ChargeMoveSpeed/3));
            }
            //
            if(ChargesCurrentWire = SC.PlayerObject.GetComponent<ChracterController>().PlayerCurrentWire)
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
        if (transform.position.x > ChargesCurrentWire.GetComponent<Wires>().AnchorRight+0.5f || transform.position.x < ChargesCurrentWire.GetComponent<Wires>().AnchorLeft-0.5f)
        {
            ChargeFailState();
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
                }
                else
                {
                    AM.Hit_source.PlayOneShot(AM.Hit);
                    Destroy(gameObject); 
                    AM.Hit_source.PlayOneShot(AM.Hit);
                }
                //currently destroying birds on collisions may need to run a function for them to leave scene or some other score behaviours
                SC.Score += collision.gameObject.GetComponent<crowMove>().ScoreForBird;
                SC.ScoreUpdate();
                Destroy(collision.gameObject);
                AM.Hit_source.PlayOneShot(AM.Hit);
                SC.Score++;
            }
            else if (isReturningCharge == true && collision.gameObject.tag == "Player")
            {
                // destroy returinging charge on collision with player, may have to change function depending on hwo we want return charges to behave.
                hasTriggered = true;
                AM.Hit_source.PlayOneShot(AM.Hit);
                //SC.Score++;
                //SC.ScoreUpdate();
                Destroy(gameObject);
                AM.Hit_source.PlayOneShot(AM.Hit);
            }
        }
    }
    public void ChargeFailState()
    {
        Debug.Log("Charge Fail State");
        AM.FailSound_source.PlayOneShot(AM.Fail);
        //destroy for now will have to change things depeneding on how we record fail states
        SC.RestartLevel();
    }
}
