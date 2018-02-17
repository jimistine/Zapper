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
	public AudioClip VOClip_1;
	public AudioClip VOClip_2;
	public AudioClip VOClip_3;
	public AudioClip VOClip_4;
	public AudioClip VOClip_5;
	public AudioClip VOClip_6;
	public AudioClip VOClip_7;
	public AudioClip VOClip_8;
	public AudioClip VOClip_9;
	
	public void VO_1()
	{ VO_source.PlayOneShot(VOClip_1);}
	
	public void VO_2()
	{ VO_source.PlayOneShot(VOClip_2);}
}
