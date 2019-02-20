using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
 
    private bool canWalk = true; //can monsters walk?
  
    //components references
    Rigidbody rb;
    Animator anim;
    NavMeshAgent agent;
    

    public GameObject scarer;
    private GameObject[] warpPoints;
    private GameObject[] destinationPoints;

    private GameObject player;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
        warpPoints = GameObject.FindGameObjectsWithTag("WarpPoint");
        destinationPoints = GameObject.FindGameObjectsWithTag("Destination");

        scarer = GameObject.FindGameObjectWithTag("ScareFactor");
    }

    void Start()
    {
        int random = Random.Range(0, warpPoints.Length);
        int randomDestination = Random.Range(0, destinationPoints.Length);

        agent.Warp(warpPoints[random].transform.position);

        agent.SetDestination(destinationPoints[randomDestination].transform.position);

        print(randomDestination);
        Rotate();
    }

    //TODO
    private void Update()
    {
        if(agent.remainingDistance <= 0.5)
        {
            anim.SetBool("Scare", true);
            Rotate();
        }
    }

    void Rotate() //rotate towards player
    {
        Vector3 rotationTowardsTarget = player.transform.position - transform.position;

        rotationTowardsTarget.y = 0f;

        Quaternion rotation = Quaternion.LookRotation(rotationTowardsTarget);
        rb.MoveRotation(rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ScareFactor"))
        {
            scarer.GetComponent<ScareFactor>().AddToList(this.gameObject);
        }
    }
}
