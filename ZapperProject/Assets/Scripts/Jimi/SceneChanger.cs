using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

	public Camera MainCam;
	public GameObject ProtoPlayer;
	public Color NewBackground;
	public Color NewPlayerColor;
	public Sprite NewPlayerSprite;
	public SpriteRenderer Player_SR;

	public SceneController SC;

	public GameObject HealthText;
	public int TimeToTurnOnText;
	public int TimeToTurnOffText;
	
	// Use this for initialization
	void Start ()
	{
		SC = FindObjectOfType<SceneController>();
		Player_SR = ProtoPlayer.GetComponent<SpriteRenderer>();
	}

	public void Change_Background()
	{
		MainCam.backgroundColor = NewBackground;
	}

	public void Change_Player_Sprite()
	{
		Player_SR.sprite = NewPlayerSprite;
		Player_SR.color = NewPlayerColor;
	}
	
	//Read lives remaining from SC, when at 0, activate a UI object that tells the player to pay attention to Jimi, wait 
	//5 seconds, then turn it back off
	void Update()
	{
		if (SC.CurrentHealth == 0)
		{
			
			StartCoroutine(Text_On_Off());
		}
	}

	IEnumerator Text_On_Off()
	{
		yield return new WaitForSeconds(TimeToTurnOnText);
		HealthText.SetActive(true);
		yield return new WaitForSeconds(TimeToTurnOffText);
		HealthText.SetActive(false);
	}
}
