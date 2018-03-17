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

    public float ChargesPositionOffsetY;

    public bool canSpawn;
	public Animator anim; 

    // Use this for initialization
    void Start () {

        StartPositionLeft = AnchorLeft;
        StartPositionRight = AnchorRight;
		anim = GetComponent<Animator> (); 

        

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

		if (Input.GetKeyDown (KeyCode.A)) {


			anim.SetBool ("zapped_wire", true); 
		}
			
    }

	public void wire_1_zap () {

		anim.SetBool ("zapped_wire", true); 

	}

	public void wire_2_zap () {

		anim.SetBool ("zapped_wire_2", true); 

	}

	public void wire_3_zap () {

		anim.SetBool ("zapped_wire_3", true); 

	}

	public void wire_4_zap () {

		anim.SetBool ("zapped_wire_4", true); 

	}

	public void wire_1_normal () {

		anim.SetBool ("zapped_wire", false); 

	}

	public void wire_2_normal () {

		anim.SetBool ("zapped_wire_2", false); 

	}

	public void wire_3_normal () {

		anim.SetBool ("zapped_wire_3", false); 

	}

	public void wire_4_normal () {

		anim.SetBool ("zapped_wire_4", false); 

	}


}
