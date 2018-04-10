using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

	public int VO_Delay;
	
	public AudioSource Hit_source;
	public AudioSource Shoot_source;
	public AudioSource FailSound_source;
	public AudioSource VO_source;
	public AudioSource Music_source;
	public AudioSource Ambient_source;

	
	public AudioClip Shoot;
	public AudioClip Fail;
	public AudioClip Hit;
	public AudioClip Music;
	public AudioClip Ambient;

	public AudioMixerSnapshot Wagner;
	public AudioMixerSnapshot NormalAmbient;
	
//	public void VO_1()
//	{ VO_source.PlayOneShot(VOClip_1);}
//	
//	public void VO_2()
//	{ VO_source.PlayOneShot(VOClip_2);}

	public void Play_Music()
	{
		Music_source.Play();
		Wagner.TransitionTo(1);
	}

	public void Stop_Muisc()
	{
		Music_source.Stop();
		NormalAmbient.TransitionTo(1);
	}
	
	public void Play_Ambient()
	{
		Ambient_source.Play();
	}

	public void Stop_Ambient()
	{
		Ambient_source.Stop();
	}
}
