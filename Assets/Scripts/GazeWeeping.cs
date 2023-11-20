using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;
using UnityEngine.AI;

public class GazeWeeping : GazeObject
{
    private NavMeshAgent agent;
    private GameObject player;
    public GameObject linkedDoor;
    private bool isAlive = false;

    void Start()
    {
        // Eyetracking
        gazeAware = GetComponent<GazeAware>();

        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void LateUpdate()
    {
        if (gazeAware.HasGazeFocus)
        {
            agent.isStopped = true;
            isAlive = false;
        }
        else if (!linkedDoor.GetComponent<DoorController>().isActiveAndEnabled)
        {
            agent.isStopped = false;
            isAlive = true;
        }

        if (isAlive)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
