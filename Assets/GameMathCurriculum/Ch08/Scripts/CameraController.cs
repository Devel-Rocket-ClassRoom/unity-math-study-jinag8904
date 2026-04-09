using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
    public float speed = 1f;
    public float distance = 10f;
    public float smoothTime = 1f;
    public Transform player;

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + (transform.position - player.position).normalized * distance, ref velocity, smoothTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), 1f);

        if (Input.GetKey(KeyCode.Q))    // 플레이어를 축으로 반시계방향
        {
            transform.RotateAround(player.position, Vector3.down, speed);
        }

        if (Input.GetKey(KeyCode.E))    // 시계방향
        {
            transform.RotateAround(player.position, Vector3.up, speed);
        }
    }
}
