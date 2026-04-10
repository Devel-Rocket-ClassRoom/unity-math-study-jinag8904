using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public enum Status { Dropped, Stopped }
    public Status state = Status.Stopped;

    public Terrain terrain;
    private Vector3 destination;

    private void Awake()
    {
        //destination = transform.position;
    }

    void Update()
    {
        if (state == Status.Dropped)
            transform.position = new Vector3(transform.position.x, terrain.SampleHeight(transform.position), transform.position.z);
    }
}
