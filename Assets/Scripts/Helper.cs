using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Helper : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerScript>().transform;
        var targets = FindObjectsOfType<ObjectScript>();
        NavMeshPath path = new NavMeshPath();
        int minCorners = int.MaxValue;
        Vector3 dist = Vector3.zero;
        bool isHavePath = false;
        foreach(var target in targets)
        {
            agent.CalculatePath(target.transform.position, path);
            Debug.Log(target.transform.position + "length: " + path.corners.Length + ", status: " +path.status);
            if (minCorners > path.corners.Length && path.status == NavMeshPathStatus.PathComplete)
            {
                isHavePath = true;
                minCorners = path.corners.Length;
                dist = target.transform.position;
                Debug.Log("Dist: " + dist);
            }
        }
        if (isHavePath) agent.destination = dist;
        else
        {
            player.GetComponent<PlayerScript>().DeactivateHelper();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if ((agent.remainingDistance < 1  && agent.remainingDistance != 0) || Vector3.Distance(transform.position, player.position) > 30)
        {
            Debug.Log(agent.remainingDistance + "; " + Vector3.Distance(transform.position, player.position));
            player.GetComponent<PlayerScript>().DeactivateHelper();
            Destroy(gameObject);
        }
    }
}
