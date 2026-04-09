using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        if (Input.anyKey)
        {
            float vert = Input.GetAxis("Vertical");
            float hori = Input.GetAxis("Horizontal");

            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(hori, 0f, vert), Time.deltaTime * speed);
        }
    }
}
