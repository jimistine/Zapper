using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTimer : MonoBehaviour
{

	public float TimeToQuit;
	
	public void StartCountdownToQuit()
	{
		StartCoroutine(CountdownToQuit());
	}
    
	IEnumerator CountdownToQuit()
	{
		yield return new WaitForSeconds(TimeToQuit);
		Debug.Log("Quitting");
		Application.Quit();
	}
}
