using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

    
    private float health = 100;
    private ScareFactor scareScript;


    private GameObject waveManager;
    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    // Use this for initialization
    void Start () {
        waveManager = GameObject.FindWithTag("WaveManager");
        scareScript = GameObject.FindWithTag("ScareFactor").GetComponent<ScareFactor>();

        scareScript.monsterTrack.Add(this.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
    }

    public void TakeDamage(float amount) {

        health -= amount;
        if(health <= 0)
        {
            Kill();
        }
          
    }

    void Kill()
    {

        //TODO spawn some particle fx

        scareScript.RemoveFromList(this.gameObject);
        Destroy(gameObject);
        


    }
}
