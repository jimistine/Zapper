using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Memory : MonoBehaviour {
    public bool WonFirstRound;
    public bool WonSecondRound;
    public bool WonThirdRound;
    
    public bool PlayedFirstRound;
    public bool PlayedSecondRound;
    public bool PlayedThirdRound;

    public bool checkPoint1Reahced; //wire 1
    public bool checkPoint2Reahced; //wire 4
    public bool checkPoint3Reahced; //wire 3

    public float CheckPoint1Length;
    public float CheckPoint2Length;
    public float CheckPoint3Length;

    public SceneController SC;

    public bool DebbugerControls = false;
    public bool IsTemp = false;
    // Use this for initialization
    void Start () {
        SC = FindObjectOfType<SceneController>();
        UpdateMountainSceneOnLoad();
    }
	
	// Update is called once per frame
	void Update () {
       if (IsTemp == false)
        {
            DontDestroyOnLoad(transform.gameObject);
        }

        if (SC.PlayerObject.transform.position.y >= CheckPoint1Length && checkPoint1Reahced == false)
        {
            checkPoint1Reahced = true;
        }
        if (SC.PlayerObject.transform.position.y >= CheckPoint2Length && checkPoint2Reahced == false)
        {
            checkPoint2Reahced = true;
        }
        if (SC.PlayerObject.transform.position.y >= CheckPoint3Length && checkPoint3Reahced == false)
        {
            checkPoint3Reahced = true;
            UnlockDebugger();
        }
        if (SC.isMountainLevel == true)
        {
            if (checkPoint1Reahced == true && SC.WireOneObject.GetComponent<Wires>().canSpawn == true)
            {
                SC.WireOneObject.GetComponent<Wires>().canSpawn = false;
                SC.PlayerObject.GetComponent<ChracterController>().MinWirePosition++;
            }
            if (checkPoint2Reahced == true && SC.WireFourObject.GetComponent<Wires>().canSpawn == true)
            {
                SC.WireFourObject.GetComponent<Wires>().canSpawn = false;
                SC.PlayerObject.GetComponent<ChracterController>().MaxWirePosition--;
            }
            if (checkPoint3Reahced == true && SC.WireThreeObject.GetComponent<Wires>().canSpawn == true)
            {
                SC.WireThreeObject.GetComponent<Wires>().canSpawn = false;
                SC.PlayerObject.GetComponent<ChracterController>().MaxWirePosition--;
            }
        }
        if (checkPoint1Reahced && SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY <= CheckPoint1Length)
        {
            SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY = CheckPoint1Length;
        }
        if (checkPoint2Reahced && SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY <= CheckPoint2Length)
        {
            SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY = CheckPoint2Length;
        }
        if (checkPoint3Reahced && SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY <= CheckPoint3Length)
        {
            SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY = CheckPoint3Length;
        }
        if (DebbugerControls == true && Input.GetKey(KeyCode.LeftControl)&&Input.GetKey(KeyCode.LeftAlt))
        {
            Debug.Log("Debugger");
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SceneManager.LoadScene("12_ArcadeScene_Birds_4Wire");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SceneManager.LoadScene("12_ArcadeScene_Prototype");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("12_ArcadeScene_Factory");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("12_ArcadeScene_MtTest 2");
            }
        }
    }
    public void StoreMemory(int x, bool y)
    {
        if (x == 1)
        {
            WonFirstRound = y;
            PlayedFirstRound = true;
        }
        if (x == 2)
        {
            WonSecondRound= y;
            PlayedSecondRound= true;
        }
        if (x == 3)
        {
            WonThirdRound = y;
            PlayedThirdRound= true;
        }
    }
    public void UpdateMountainSceneOnLoad()
    {
        if (checkPoint3Reahced == true)
        {
            SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY = CheckPoint3Length;
        }
        else if (checkPoint2Reahced == true)
        {
            SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY = CheckPoint2Length;
        }
        else if (checkPoint1Reahced == true)
        {
            SC.PlayerObject.GetComponent<ChracterController>().PlayersStartingPositionY = CheckPoint1Length;
        }

        SC.PlayerObject.GetComponent<ChracterController>().CurrentWirePositionX = 2;
        SC.PlayerObject.GetComponent<ChracterController>().FindCurrentWire();
        SC.PlayerObject.GetComponent<ChracterController>().IsinStartPosition = false;
    }
    public void UnlockDebugger()
    {
        DebbugerControls = true;
    }
}
