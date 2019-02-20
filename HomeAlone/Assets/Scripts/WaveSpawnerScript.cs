using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{
    private ScareFactor scareScript;

    public Transform spawnPoint;
    public GameObject[] enemies = new GameObject[8];

    public float timer;
    public float minTimer;

    void Start()
    {
        Invoke("SpawnEnemyRandom", timer);
        scareScript = GameObject.FindWithTag("ScareFactor").GetComponent<ScareFactor>();
    }

    void SpawnEnemyRandom()
    {
        int random = Random.Range(0, enemies.Length);
        GameObject go = enemies[random];

        Instantiate(go, spawnPoint.position, Quaternion.identity);

        timer -= 0.1f;

        if (timer < minTimer) timer = minTimer;

        Invoke("SpawnEnemyRandom", timer);
    }
 

}
