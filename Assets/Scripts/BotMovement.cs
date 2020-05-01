﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BotMovement : MonoBehaviour
{
    [System.Flags]
    public enum DamageType
    {
        Near = 1,
        Distant = 2
    }

    public float radiusTrigger = 10;
    public int live = 15;
    public DamageType damageType;
    public GameObject[] wayPoints;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3[] points;
    private bool isActivate = false, isBlocked = false;
    private int currentIndex = 0;
    private NavMeshPath path;
    void Start()
    {
        path = new NavMeshPath();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        points = new Vector3[wayPoints.Length + 1];
        points[0] = transform.position;
        for (int i = 0; i < wayPoints.Length; i++)
        {
            points[i + 1] = wayPoints[i].transform.position;
        }
        if (wayPoints.Length > 0)
        {
            agent.destination = points[1];
        }
    }

    private void Update()
    {
        if (isActivate)
        {
            agent.destination = player.transform.position;
            if(agent.path.status != NavMeshPathStatus.PathComplete && !isBlocked)
            {
                StartCoroutine(WaitPlayer());
                isBlocked = true;
            }
        }
        else if (Vector3.Distance(player.transform.position, transform.position) <= radiusTrigger)
        {
            agent.CalculatePath(player.transform.position, path);
            if(path.status == NavMeshPathStatus.PathComplete) isActivate = true;
        }
        else if (agent.remainingDistance < 1)
        {
            currentIndex++;
            agent.destination = points[currentIndex % points.Length];
        }
    }

    private void OnDrawGizmos()
    {
        NavMeshPath path = new NavMeshPath();
        Gizmos.color = new Color(1, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusTrigger);
        Gizmos.color = Color.blue;
        if (wayPoints.Length > 0)
        {
            var prevPos = transform.position;
            foreach (var point in wayPoints)
            {
                if (point == null) continue;
                NavMesh.CalculatePath(prevPos, point.transform.position, NavMesh.AllAreas, path);
                foreach (var p in path.corners)
                {
                    Gizmos.DrawLine(prevPos, p);
                    prevPos = p;
                }
            }
        }
    }

    public void SetDamage(int damage)
    {
        live -= damage;
        if (live <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitPlayer()
    {
        yield return new WaitForSeconds(3);
        agent.CalculatePath(player.transform.position, path);
        if(path.status != NavMeshPathStatus.PathComplete)
        {
            isActivate = false;
            agent.destination = points[currentIndex % points.Length];
        }
        isBlocked = false;
    }
}
