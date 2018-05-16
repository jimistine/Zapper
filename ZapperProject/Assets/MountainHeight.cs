using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MountainHeight : MonoBehaviour {

	public GameObject HeightUI;
	public int Height = 0;
	public SceneController SC;
	
	// Use this for initialization
	void Start () {
		SC = FindObjectOfType<SceneController>();
	//	Height = SC.PlayerObject.transform.position.y;

	}
	
	// Update is called once per frame
	void Update ()
	{
		HeightUI.GetComponent<Text>().text = " "+Mathf.Round(SC.PlayerObject.transform.position.y)+" FT. ";	
	}
}
