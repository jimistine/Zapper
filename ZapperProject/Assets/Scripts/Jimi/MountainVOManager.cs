﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
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

		if (MemoryOBJ.GetComponent<Memory>().PlayedMtn_1)
		{
			Flowchart.BroadcastFungusMessage("second");
		//	Destroy(this);
		}
		else
		{
			Flowchart.BroadcastFungusMessage("first");
		}
	}

	public void UnlockDebugOnMem()
	{
		MemoryOBJ.GetComponent<Memory>().UnlockDebugger();
	}

	public void PlayTopOnMem()
	{
		MemoryOBJ.GetComponent<Memory>().PlayTop();
	}
}