using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour {
    public float PlayersStartPositionX;
    public float PlayersStartPositionY;
    public bool PlayerStartRight = true;
    public float AnchorLeft = -6f;
    public float AnchorRight = 6f;
    public float StartPositionLeft;
    public float StartPositionRight;
    public float PlayerPositionOffsetY;

    // Use this for initialization
    void Start () {

        StartPositionLeft = AnchorLeft;
        StartPositionRight = AnchorRight;

        

    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerStartRight == true)
        {
            PlayersStartPositionX = StartPositionRight;
        }
        if (PlayerStartRight == false)
        {
            PlayersStartPositionX = StartPositionLeft;
        }

        PlayersStartPositionY = transform.position.y + PlayerPositionOffsetY;

    }
}
