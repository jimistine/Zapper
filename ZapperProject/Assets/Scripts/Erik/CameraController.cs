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
            if (SC.PlayerObject.transform.position.y > 0.5)
            {
                Vector3 newPosition = transform.position;
                newPosition.y = Mathf.Lerp(transform.position.y, SC.PlayerObject.transform.position.y, Time.deltaTime);
                transform.localPosition = newPosition;
            }
        }
		
	}
}
