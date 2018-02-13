using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public AudioClip VO;
	
	// Use this for initialization
	void Start () {
		VO_source.PlayDelayed(VO_Delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
