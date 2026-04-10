using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public bool isReturning;

    private Terrain terrain;
    public float timeReturn = 2f;
    private float timer;
    public Vector3 originalPos;
    private Vector3 startPos;

    private void Awake()
    {
        terrain = Terrain.activeTerrain;
    }

    private void Update()
    {
        if (isReturning)
        {
            timer += Time.deltaTime / timeReturn;
            Vector3 newPos = Vector3.Lerp(startPos, originalPos, timer);
            newPos.y = terrain.SampleHeight(newPos);
            transform.position = newPos;

            if (timer > 1f)
            {
                isReturning = false;
                transform.position = originalPos;
                timer = 0f;
            }
        }
    }

    private void ResetDrag()
    {
        isReturning = false;
        timer = 0f;
        originalPos = Vector3.zero;
        startPos = Vector3.zero;
    }

    public void DragStart()
    {
        ResetDrag();
        originalPos = transform.position;
    }

    public void DragEnd()
    {
        ResetDrag();
    }

    public void Return()
    {
        timer = 0f;
        isReturning = true;
        startPos = transform.position;
    }
}
