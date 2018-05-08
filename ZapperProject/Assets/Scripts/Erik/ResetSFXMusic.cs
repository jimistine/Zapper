using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSFXMusic : MonoBehaviour {
    public AudioManager AM;

    // Use this for initialization
    void Start () {
        AM = FindObjectOfType<AudioManager>();

    }
	
	// Update is called once per frame
	void Update () {

        AM.RestoreMaster();
        AM.RestoreSFX();

    }
}
