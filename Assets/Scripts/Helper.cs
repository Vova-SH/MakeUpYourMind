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
        var targets = GameObject.FindObjectsOfType <ObjectScript> ();
        NavMeshPath path = new NavMeshPath();
        int minCorners = int.MaxValue;
        Vector3 dist = Vector3.zero;
        foreach(var target in targets)
        {
            agent.CalculatePath(target.transform.position, path);
            if(minCorners > path.corners.Length)
            {
                minCorners = path.corners.Length;
                dist = target.transform.position;
            }
        }
        if (!dist.Equals(Vector3.zero)) agent.destination = dist;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (agent.remainingDistance < 1 || Vector3.Distance(transform.position, player.position) > 30)
        {
            player.GetComponent<PlayerScript>().DeactivateHelper();
            Destroy(gameObject);
        }
    }
}
