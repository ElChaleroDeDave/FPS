using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    public Transform[] destinations;
    
    private int i = 0;

    [Header("       FollowPlayer      ")]
    
    public bool followPlayer;    

    private GameObject player;

    private float distanceToPlayer;

    public float distanceToFollowPlayer = 10;

    public float distanceToFollowPath = 2;

    void Start()
    {
        navMeshAgent.destination = destinations[i].transform.position;
        player = FindObjectOfType<PlayerMove>().gameObject;

    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }

    }

    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++; 
            }
            else
        {
            i = 0;
        }
        }
        

    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

}
