using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontScareScript : MonoBehaviour {

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Monster"))
        {

            audioSource.Play();

        }

    }
}
