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

	public void CheckStateToLoad()
	{
		if (MemoryOBJ.GetComponent<Memory>().PlayedFirstRound &&
		    MemoryOBJ.GetComponent<Memory>().PlayedSecondRound == false)
		{
			Flowchart.BroadcastFungusMessage ("Load Round 2");
		}
	}
}
