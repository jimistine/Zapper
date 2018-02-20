using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFollow : MonoBehaviour {

	RectTransform this_rectTransform;
	public Vector2 panelAnchorPos;
	public ChracterController CC;
	
	void Start()
	{
		//Fetch the RectTransform from the GameObject
		this_rectTransform = GetComponent<RectTransform>();
		CC = FindObjectOfType<ChracterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		panelAnchorPos = new Vector2(CC.playerX * 100, CC.playerY * 100 + 600);

		this_rectTransform.anchoredPosition = panelAnchorPos;
	}
}
