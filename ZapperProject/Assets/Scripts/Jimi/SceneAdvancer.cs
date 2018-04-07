using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class SceneAdvancer : MonoBehaviour
{

	public GameObject MemoryOBJ;
	
	// Use this for initialization
	void Start ()
	{
		MemoryOBJ = GameObject.FindGameObjectWithTag("Memory");
	}

	void Update()
	{
		// TO ROUND 4
//		if (MemoryOBJ.GetComponent<Memory>().WonThirdRound)
//		{
//			Flowchart.BroadcastFungusMessage("Load round 4 (Won 3)");
//		}
//	
//		if (MemoryOBJ.GetComponent<Memory>().WonSecondRound &&
//		    MemoryOBJ.GetComponent<Memory>().PlayedThirdRound &&
//		    MemoryOBJ.GetComponent<Memory>().WonThirdRound == false)
//		{
//			Flowchart.BroadcastFungusMessage("Load round 4 (Won 2 Lost 1)");
//		}
//	
//		if (MemoryOBJ.GetComponent<Memory>().WonFirstRound == false &&
//			MemoryOBJ.GetComponent<Memory>().WonSecondRound == false &&
//		    MemoryOBJ.GetComponent<Memory>().WonThirdRound)
//		{
//			Flowchart.BroadcastFungusMessage("Load round 4 (Won 1 Lost 2)");
//		}
//
//		if (MemoryOBJ.GetComponent<Memory>().WonFirstRound == false &&
//		    MemoryOBJ.GetComponent<Memory>().WonSecondRound == false &&
//		    MemoryOBJ.GetComponent<Memory>().PlayedThirdRound &&
//		    MemoryOBJ.GetComponent<Memory>().WonThirdRound == false)
//		{
//			Flowchart.BroadcastFungusMessage("Load round 4 (Lost 3)");
//		}
	}
	
	public void CheckStateToLoad()
	{
		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedSecondRound == false)
		{
			Flowchart.BroadcastFungusMessage ("Load Round 2");
		}
		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedSecondRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedThirdRound == false &&
		    MemoryOBJ.GetComponent<Memory>().WonSecondRound)
		{
			Flowchart.BroadcastFungusMessage ("First VO (Won)");
		}
		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedSecondRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedThirdRound == false &&
		    MemoryOBJ.GetComponent<Memory>().WonSecondRound == false)
		{
			Flowchart.BroadcastFungusMessage ("First VO (Lost)");
		}
//
//		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
//			MemoryOBJ.GetComponent<Memory>().PlayedSecondRound &&
//			MemoryOBJ.GetComponent<Memory>().PlayedThirdRound &&
//			MemoryOBJ.GetComponent<Memory>().WonSecondRound == false &&
//			MemoryOBJ.GetComponent<Memory>().WonThirdRound == false)
//		{
//			Flowchart.BroadcastFungusMessage ("Reload Round 3");
//		}
		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedSecondRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedThirdRound &&
		    MemoryOBJ.GetComponent<Memory>().WonSecondRound == false)
		{
			Flowchart.BroadcastFungusMessage ("Music Loop to 2Wires");
		}
		
		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedSecondRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedThirdRound &&
		    MemoryOBJ.GetComponent<Memory>().WonSecondRound)
		{
			Flowchart.BroadcastFungusMessage ("Music Loop to 4Wires");
		}
	}

//	public void CheckOther()
//	{
//		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
//		    MemoryOBJ.GetComponent<Memory>().PlayedSecondRound
//			MemoryOBJ.GetComponent<Memory>().PlayedThirdRound == false)
//		{
//			Flowchart.BroadcastFungusMessage("Play music fail");
//		}
//	}
}
