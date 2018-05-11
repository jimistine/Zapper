using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemTagger : MonoBehaviour {

	public GameObject MemoryOBJ;
	
	// Use this for initialization
	void Start ()
	{
		MemoryOBJ = GameObject.FindGameObjectWithTag("Memory");
		MemoryOBJ.GetComponent<Memory>().PlayedMtn_1 = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
