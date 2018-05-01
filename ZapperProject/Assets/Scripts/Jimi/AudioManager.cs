using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public SceneController SC;
	
	public int VO_Delay;
	
	public AudioSource Hit_source;
	public AudioSource Shoot_source;
	public AudioSource FailSound_source;
	public AudioSource VO_source_1;
	public AudioSource VO_source_2;
	public AudioSource VO_source_3;
	public AudioSource VO_source_4;
	public AudioSource VO_source_5;
	public AudioSource VO_source_6;
	public AudioSource VO_source_7;
	public AudioSource VO_source_8;
	public AudioSource Music_source;
	public AudioSource Ambient_source;
	public AudioSource MiscSFX_source_1;
	
	public AudioClip Shoot;
	public AudioClip Fail;
	public AudioClip Hit;
	public AudioClip Music;
	public AudioClip Ambient;

	public AudioMixerSnapshot Wagner;
	public AudioMixerSnapshot NormalAmbient;

	void Start()
	{
		SC = FindObjectOfType<SceneController>();
	}

	public void Play_Music()
	{
		Music_source.Play();
		if (SC.isFactory)
		{
			Wagner.TransitionTo(1);
		}
	}

	public void Stop_Muisc()
	{
		Music_source.Stop();
		if (SC.isFactory)
		{
			NormalAmbient.TransitionTo(1);
		}
	}
	
	public void Play_Ambient()
	{
		Ambient_source.Play();
	}

	public void Stop_Ambient()
	{
		Ambient_source.Stop();
	}
	public void Play_VO_1()
	{
		VO_source_1.Play();
	}
	
	public void Play_VO_2()
	{
		VO_source_2.Play();
	}
	
	public void Play_VO_3()
	{
		VO_source_3.Play();
	}
	
	public void Play_VO_4()
	{
		VO_source_4.Play();
	}
	
	public void Play_VO_5()
	{
		VO_source_5.Play();
	}
	
	public void Play_VO_6()
	{
		VO_source_6.Play();
	}
	
	public void Play_VO_7()
	{
		VO_source_7.Play();
	}
	
	public void Play_VO_8()
	{
		VO_source_8.Play();
	}

	public void Play_MiscSFX_1()
	{
		MiscSFX_source_1.Play();
	}
	
	public void Stop_MiscSFX_1()
	{
		MiscSFX_source_1.Stop();
	}
	
}
