using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AudioManager : MonoBehaviour
{

	public int VO_Delay;
	
	public AudioSource HitCrow_source;
	public AudioSource ShootCharge_source;
	public AudioSource Explosion_source;
	public AudioSource VO_source;

	public AudioClip ShootCharge;
	public AudioClip Explosion;
	public AudioClip HitCrow;
	public AudioClip VO_Intro1;
	public AudioClip VO_Intro2;
	
	
	public void VO_1()
	{ VO_source.PlayOneShot(VO_Intro1);}
	
	public void VO_2()
	{ VO_source.PlayOneShot(VO_Intro2);}
}
