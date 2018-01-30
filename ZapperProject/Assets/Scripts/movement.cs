using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class movement : MonoBehaviour
{
	public float pX = 5.164f;
	public float pY;
	public float pZ;
	
	public float wireEnd;
	private Collider2D w_Collider;

	private int numWires;
	
	// Use this for initialization
	void Start()
	{
		
		pX = gameObject.transform.position.x;
		pY = gameObject.transform.position.y;
		pZ = gameObject.transform.position.z;
		
		//List<Wire> wires = new List<Wire>();

		//wires.Add(new Wire(wireTracker.w_Max_1));
		//wires.Add(new Wire(wireTracker.w_Max_2));
		//wires.Add(new Wire(wireTracker.w_Max_3));
		//wires.Add(new Wire(wireTracker.w_Max_4));

		//numWires = wires.Count;
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
			//gameObject.transform.Translate( + 1);

			//	Debug.Log("Player Y – " + pY);
			}
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				//gameObject.transform.Translate(Wire - 1);
			//	Debug.Log("Player Y – " + pY);
			}
		}
//		/*
//		else
//		{
//			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
//			{
//				gameObject.transform.Translate(new Vector3(pX, pY, pZ));
//			}
//
//			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
//			{
//				gameObject.transform.Translate(new Vector3(pX, pY, pZ));
//			}
//		}
//		*/
//
//		// Tracking
//		if (pY >= Bottom_1 && pY <= Top_1)
//		{
//			GM.Me.PlayerLocation = 1;
//		}
//		if (pY >= Bottom_2 && pY <= Top_2)
//		{
//			GM.Me.PlayerLocation = 2;
//		}
//		if (pY >= Bottom_3 && pY <= Top_3)
//		{
//			GM.Me.PlayerLocation = 3;
//		}
//		if (pY >= Bottom_4 && pY <= Top_4)
//		{
//			GM.Me.PlayerLocation = 4;
//		}
	/*
	if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				player wire + 1;
			}
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				player wire - 1						}
	*/
	     
	}

