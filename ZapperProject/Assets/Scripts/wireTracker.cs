using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireTracker : MonoBehaviour
{

	public GameObject Wire_1;
	public GameObject Wire_2;
	public GameObject Wire_3;
	public GameObject Wire_4;
	
	private Collider2D w_Collider_1;
	private Collider2D w_Collider_2;
	private Collider2D w_Collider_3;
	private Collider2D w_Collider_4;
	
	public static Vector3 w_Max_1;
	public static Vector3 w_Max_2;
	public static Vector3 w_Max_3;
	public static Vector3 w_Max_4;
	
	
	void Start()
	{
	//This gets the upper right corner of the collider on each wire - jimi
		w_Collider_1 = Wire_1.GetComponent<Collider2D>();
		w_Max_1 = w_Collider_1.bounds.max;
		
		w_Collider_2 = Wire_2.GetComponent<Collider2D>();
		w_Max_2 = w_Collider_2.bounds.max;
		
		w_Collider_3 = Wire_3.GetComponent<Collider2D>();
		w_Max_3 = w_Collider_3.bounds.max;
		
		w_Collider_4 = Wire_4.GetComponent<Collider2D>();
		w_Max_4 = w_Collider_4.bounds.max;
		
	//	Debug.Log(gameObject.name + " | Max – " + w_Max);
	}
	//this was supposed to tell us where the player was but never really worked - jimi
//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if (gameObject.name == "Wire_1"){
//			GM.Me.PlayerLocation = 1;
//			Debug.Log("On " + gameObject.name);
//		}
//		if (gameObject.name == "Wire_2"){
//			GM.Me.PlayerLocation = 2;
//			Debug.Log("On " + gameObject.name);
//		}
//		if (gameObject.name == "Wire_3"){
//			GM.Me.PlayerLocation = 3;
//			Debug.Log("On " + gameObject.name);
//		}
//		if (gameObject.name == "Wire_4"){
//			GM.Me.PlayerLocation = 4;
//			Debug.Log("On " + gameObject.name);
//		}
//	}
	
}
