using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MountainVOManager : MonoBehaviour {

	public GameObject MemoryOBJ;
	
	void Start ()
	{
		MemoryOBJ = GameObject.FindGameObjectWithTag("Memory");
	}

	public void CheckStateToLoad()
	{
		if (MemoryOBJ.GetComponent<Memory>().PlayedMtn_1 &&
		    MemoryOBJ.GetComponent<Memory>().PlayedMtn_2 ==false)
		{
			Flowchart.BroadcastFungusMessage("first");
		}
		
		if (MemoryOBJ.GetComponent<Memory>().PlayedMtn_1 &&
		    MemoryOBJ.GetComponent<Memory>().PlayedMtn_2)
		{
			Flowchart.BroadcastFungusMessage("second");
		}
	}
}
