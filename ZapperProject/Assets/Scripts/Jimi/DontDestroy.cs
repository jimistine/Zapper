using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroy : MonoBehaviour
{

	public bool PlayedBlock;
	public GameObject MemoryOBJ;
	
	public static int menuScreenBuildIndex = 0;
	
	// Use this for initialization
	void Awake ()
	{
		SceneManager.activeSceneChanged += DestroyOnReset;
	}

	void Start()
	{
		MemoryOBJ = GameObject.FindGameObjectWithTag("Memory");
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad(transform.gameObject);
	}

	void DestroyOnReset(Scene oldScene, Scene newScene)
	{
		if (newScene.buildIndex == menuScreenBuildIndex)
		{
			Destroy(this.gameObject);
		}
	}

	public void DestroyAftePlayed()
	{
		if(PlayedBlock) 
		{
			Destroy(this.gameObject);
		}	
	}
	
	public void MarkAsPlayed()
	{
		PlayedBlock = true;
	}	
}
