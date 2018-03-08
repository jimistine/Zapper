using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {
    public bool WonFirstRound;
    public bool WonSecondRound;
    public bool WonThirdRound;
    
    public bool PlayedFirstRound;
    public bool PlayedSecondRound;
    public bool PlayedThirdRound;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        DontDestroyOnLoad(transform.gameObject);
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
}
