using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AudioManager : MonoBehaviour
{

	public int VO_Delay;
	
	public AudioSource Hit_source;
	public AudioSource Shoot_source;
	public AudioSource FailSound_source;
	public AudioSource VO_source;

	public AudioClip Shoot;
	public AudioClip Fail;
	public AudioClip Hit;
	
//	public void VO_1()
//	{ VO_source.PlayOneShot(VOClip_1);}
//	
//	public void VO_2()
//	{ VO_source.PlayOneShot(VOClip_2);}
}
