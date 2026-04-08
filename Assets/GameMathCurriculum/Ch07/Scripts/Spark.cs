using UnityEngine;

public class Spark : MonoBehaviour
{
    private float t;
    public float speed;
    public Vector3[] points = new Vector3[4];
    public float duration = 1.5f;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    void Update()
    {
        t += Time.deltaTime / duration;

        if (transform.position.x >= points[3].x) Destroy(gameObject);
        transform.position = CubicBezier(points[0], points[1], points[2], points[3], t * speed);
    }

    Vector3 CubicBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        // de Casteljau 알고리즘 — 3단계 Lerp
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);

        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(d, e, t);
    }
}
