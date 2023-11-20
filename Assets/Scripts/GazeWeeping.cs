using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GazeWeeping : GazeObject
{
    private NavMeshAgent agent;
    private GameObject player;
    public bool isAlive = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
