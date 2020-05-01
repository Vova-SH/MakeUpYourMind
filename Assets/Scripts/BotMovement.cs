using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BotMovement : MonoBehaviour
{
    public float radiusTrigger = 10;

    private NavMeshAgent agent;
    private GameObject player;
    private bool isActivate = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isActivate)
        {
            agent.destination = player.transform.position;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) <= radiusTrigger)
        {
            isActivate = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusTrigger);
    }
}
