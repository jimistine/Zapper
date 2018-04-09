using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour {
    public SceneController SC;
    public float PlayersStartPositionX;
    public float PlayersStartPositionY;
    public bool PlayerStartRight = true;
    public float AnchorLeft = -6f;
    public float AnchorRight = 6f;
    public float StartPositionLeft;
    public float StartPositionRight;
    
	public float StartPositionBottom = - 3;
    public float WirePositionTop;
    public float PlayerPositionOffsetY;

    public float ChargesPositionOffsetY;

    public bool canSpawn;
    public bool canWin = false;
	public bool isSummitWire = false;
    public Animator anim; 
	
    // Use this for initialization
    void Start () {
        SC = FindObjectOfType<SceneController>();
        StartPositionLeft = AnchorLeft;
        StartPositionRight = AnchorRight;
		anim = GetComponent<Animator> ();

        if (SC.isMountainLevel == false)
        {
            if (PlayerStartRight == true)
            {
                PlayersStartPositionX = StartPositionRight;
            }
            if (PlayerStartRight == false)
            {
                PlayersStartPositionX = StartPositionLeft;
            }

            PlayersStartPositionY = transform.position.y + PlayerPositionOffsetY;

            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool("zapped_wire", true);
            }
        }
        else if (SC.isMountainLevel == true)
        {
            PlayersStartPositionY = StartPositionBottom;
            PlayersStartPositionX = transform.position.x;
        }



    }
	
	// Update is called once per frame
	void Update () {
        
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

	// Called by fungus to toggle spawning in game
	public void set_spawn_false()
	{
		canSpawn = false;
	}
	
	public void set_spawn_true()
	{
		canSpawn = true;
	}

}
