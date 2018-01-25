using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class movement : MonoBehaviour
{
	public float pX = 5.164f;
	public float pY;
	public float pZ;
	public float topBound;
	public float bottomBound;

	public float Bottom_1;
	public float Bottom_2;
	public float Bottom_3;
	public float Bottom_4;
	public float Top_1;
	public float Top_2;
	public float Top_3;
	public float Top_4;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

//		pX = gameObject.transform.position.x;
//		pY = gameObject.transform.position.y;
//		pZ = gameObject.transform.position.z;

//		if (pY >= topBound)
//		{
//			Debug.Log("topHit");
//		}

		if (pY < topBound || pY > bottomBound)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				gameObject.transform.Translate(new Vector3(pX, pY + 2, pZ));
			}

			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				gameObject.transform.Translate(new Vector3(pX, pY - 2, pZ));
			}
		}
		/*
		else
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				gameObject.transform.Translate(new Vector3(pX, pY, pZ));
			}

			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				gameObject.transform.Translate(new Vector3(pX, pY, pZ));
			}
		}
		*/

		// Tracking
		if (pY >= Bottom_1 && pY <= Top_1)
		{
			GM.Me.PlayerLocation = 1;
		}
		if (pY >= Bottom_2 && pY <= Top_2)
		{
			GM.Me.PlayerLocation = 2;
		}
		if (pY >= Bottom_3 && pY <= Top_3)
		{
			GM.Me.PlayerLocation = 3;
		}
		if (pY >= Bottom_4 && pY <= Top_4)
		{
			GM.Me.PlayerLocation = 4;
		}
	}
}
