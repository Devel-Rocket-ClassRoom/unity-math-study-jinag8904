using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public enum Status { Dropped, Stopped }
    public Status state = Status.Stopped;

    public Terrain terrain;
    private NavMeshAgent agent;
    private Vector3 destination;

    private void Awake()
    {
        destination = transform.position;

        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
    }

    void Update()
    {
        if (state == Status.Dropped)
        {
            // 바닥에 내려놓기?
            transform.position = new Vector3(transform.position.x, terrain.SampleHeight(transform.position), transform.position.z);

            agent.SetDestination(destination);
            agent.isStopped = false;

            if (transform.position == agent.destination)
            {
                agent.isStopped = true;
                agent.SetDestination(transform.position);
                state = Status.Stopped;
            }
        }
    }
}
