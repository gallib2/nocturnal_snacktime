using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangNoises : MonoBehaviour {

    public AudioSource bangSource;
    public AudioClip[] audioClipArray;


    void Awake()
    {

    }
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MakeSomeNoise()
    {
        bangSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        bangSource.PlayOneShot(bangSource.clip);
    }
}
