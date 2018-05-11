using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

	public Camera MainCam;
	public GameObject ProtoPlayer;
	public Color NewBackground;
	public Color NewPlayerColor;
	public Sprite NewPlayerSprite;
	public SpriteRenderer Player_SR;
	
	
	// Use this for initialization
	void Start ()
	{
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
}
