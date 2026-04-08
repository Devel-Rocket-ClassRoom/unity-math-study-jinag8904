using System.Collections.Generic;
using UnityEngine;

public class CubicBazier : MonoBehaviour
{
    public Transform[] points; // p0, p3은 고정 / p1, p2는 랜덤 (높이)
    public Spark sparkPrefab;

    public float duration = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 5; i++)
            {
                var spark = Instantiate(sparkPrefab, points[0].position, transform.rotation);
                spark.speed = Random.Range(0.5f, 2f);
                spark.points[0] = points[0].position;
                spark.points[1] = new Vector3(points[1].position.x, points[1].position.y + Random.Range(-3f, 3f), points[1].position.z);
                spark.points[2] = new Vector3(points[2].position.x, points[2].position.y + Random.Range(-3f, 3f), points[2].position.z);
                spark.points[3] = points[3].position;
            }
        }
    }
}