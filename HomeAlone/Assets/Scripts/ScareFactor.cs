using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScareFactor : MonoBehaviour {

    //create a slider and attach it
    //change max scare percentage to any value you'd like and set the same value as 'max' in slider
    //set the startTimer to any value you'd like (how fast should the kid be scared?)

    public List<GameObject> monsters = new List<GameObject>();
    public List<GameObject> monsterTrack = new List<GameObject>();
  
    public Slider scareSlider;

    private int percentage;
    public int maxpercentage;

    private float timer;
    public float startTimer;

    public GameController cont;

    void Start()
    {
        percentage = 0;
   
    }

    void Update()
    {
        Debug.Log("MONSTERS" + monsters.Count);

        if (monsters.Count > 0)
        {
            foreach (GameObject go in monsters)
            {
                if (timer <= 0)
                {
                    percentage += 1;
                    timer = startTimer;
                }

                else timer -=  Time.deltaTime;

                if(percentage > maxpercentage)
                {
                    percentage = maxpercentage;
                }

            }
        }

        else
        {
               //reduce the amount if no enemies in range
               if (timer <= 0)
               {
                   percentage -= 1;
                   timer = startTimer;
               
               }
               
               else timer -= Time.deltaTime;
               
               if (percentage < 0)
               {
                   percentage = 0;
               }
          
        }

        scareSlider.value = percentage;

        //lose condition (if percentage == maxpercentage), then call end of game function
        if (percentage >= maxpercentage)
        {
            StartCoroutine(cont.GetComponent<GameController>().EndOfGame());
        }
    }

    public void AddToList(GameObject other)
    {
        monsters.Add(other);
    }

    public void RemoveFromList(GameObject go)
    {
        monsterTrack.Remove(go);
        monsters.Remove(go);

        if(monsterTrack.Count == 0)
        {
            if(monsters.Count > 0)
            {
                monsters.RemoveAt(0);
            }
        }
    }

}
