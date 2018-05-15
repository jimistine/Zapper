using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Glitcher : MonoBehaviour
{

	public Sprite new_Sprite;
	public Sprite new_Sprite2;
	public Vector2 Move1;
	public Vector2 Move2;
	public float MoveSpeed;
	public Vector3 NewScale;
	private Vector3 NewScaleGrow;

	private float GrowX;
	private float GrowY;
	private float GrowZ;
	public float GrowSpeedX;
	public float GrowSpeedY;
	public float GrowSpeedZ;
	
	public bool StartGrow;
	public bool StartMove;
	//public bool StartFlickerSprite;

	public float TimeVisible;
	public float TimeInisible;

	public IEnumerator coroutine;
	


	void Start()
	{
		GrowX = gameObject.GetComponent<Transform>().localScale.x;
		GrowY = gameObject.GetComponent<Transform>().localScale.y;
		GrowZ = gameObject.GetComponent<Transform>().localScale.z;
	}
	
	void Update()
	{
		if (StartMove)
		{
			gameObject.transform.Translate(Move1 * Time.deltaTime * MoveSpeed);
		}

		if (StartGrow)
		{
			GrowX += GrowSpeedX;
			GrowY += GrowSpeedY;
			GrowZ += GrowSpeedZ;
			
			NewScaleGrow.Set(GrowX,GrowY,GrowZ);
			
			gameObject.transform.localScale = NewScaleGrow;	
		}
	}
	
	public void ChangeSprite()
	{
		this.GetComponent<SpriteRenderer>().sprite = new_Sprite;
		Debug.Log("changed sprite!");
	}
	
	public void ChangeSprite2()
	{
		this.GetComponent<SpriteRenderer>().sprite = new_Sprite2;
		Debug.Log("changed sprite!");
	}

	public void TranslateSprite_DownRight()
	{
		gameObject.transform.Translate(Vector3.down * Time.deltaTime * 20);
		gameObject.transform.Translate(Vector3.right * 10);
	}

	public void MoveSprite()
	{
		StartMove = true;
	}

	public void Rescale()
	{
		gameObject.transform.localScale = NewScale;
	}

	public void Grow()
	{
		StartGrow = true;
	}
	
	public void FlickerText()
	{
		StartCoroutine(FlickerTimerText());
	}
	
	IEnumerator FlickerTimerText()
	{
		yield return new WaitForSeconds(TimeVisible);
	//	Debug.Log("invisible");
		gameObject.GetComponent<Text>().enabled = false;
		StartCoroutine(SetActiveText());
	}

	IEnumerator SetActiveText()
	{
		yield return new WaitForSeconds(TimeInisible);
	//	Debug.Log("visible");
		gameObject.GetComponent<Text>().enabled = true;
		StartCoroutine(FlickerTimerText());
	}
	
	
	public void FlickerSprite()
	{
		StartCoroutine(FlickerTimerSprite());
	}
	
	IEnumerator FlickerTimerSprite()
	{
		yield return new WaitForSeconds(TimeVisible);
	//	Debug.Log("invisible");
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.SetActive(false);
		StartCoroutine(SetActiveSprite());
	}

	IEnumerator SetActiveSprite()
	{
		yield return new WaitForSeconds(TimeInisible);
	//	Debug.Log("visible");
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		gameObject.SetActive(true);
		StartCoroutine(FlickerTimerSprite());
	}
	
}