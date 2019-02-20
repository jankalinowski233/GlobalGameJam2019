using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTriggerScript : MonoBehaviour {
    //public float monsterHealth = 1000;
    
    public GameObject waveManager;
    private GameObject scarearea;
    WaveSpawnerScript waveSpawnerScript;
    

    void OnTriggerEnter(Collider other) {

        if (other.tag =="Monster"){
            Debug.Log("Object Entered the trigger");
        }
    }

    void OnTriggerStay(Collider other)
    {
       
        if (other.tag == "Monster")
        {
           other.gameObject.GetComponent<MonsterScript>().TakeDamage(2);
           Debug.Log(other.gameObject.GetComponent<MonsterScript>().Health);

        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
        {
            Debug.Log("Object Exit the trigger");
        }      
    }

    
}
