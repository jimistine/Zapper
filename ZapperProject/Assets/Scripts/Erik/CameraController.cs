using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public SceneController SC;

    // Use this for initialization
    void Start () {
        SC = FindObjectOfType<SceneController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (SC.isMountainLevel == true)
        {
            if (SC.PlayerObject.transform.position.y > SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY + (Camera.main.orthographicSize/2 - 2))
            {
                Vector3 newPosition = transform.position;
                newPosition.y = Mathf.Lerp(transform.position.y, SC.PlayerObject.transform.position.y + 2, Time.deltaTime);
                if (gameObject.tag == "Health")
                {
                    newPosition.y = Mathf.Lerp(transform.position.y, SC.PlayerObject.transform.position.y + 7, Time.deltaTime);
                }
                transform.localPosition = newPosition;
            }
            if (SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().checkPoint3Reahced == true && transform.position.y <= SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().CheckPoint3Length)
            {
                transform.position = new Vector3(transform.position.x, SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().CheckPoint3Length, transform.position.z);
            }
            else if (SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().checkPoint2Reahced == true && transform.position.y <= SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().CheckPoint2Length)
            {
                transform.position = new Vector3(transform.position.x, SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().CheckPoint2Length, transform.position.z);
            }
            else if (SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().checkPoint1Reahced == true && transform.position.y <= SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().CheckPoint1Length)
            {
                transform.position = new Vector3(transform.position.x, SC.GetComponent<SceneController>().MemoryObj.GetComponent<Memory>().CheckPoint1Length, transform.position.z);
            }
        }
		
	}
}
