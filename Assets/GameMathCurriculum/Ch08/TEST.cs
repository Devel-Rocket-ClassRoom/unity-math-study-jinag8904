using UnityEngine;

public class TEST : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log($"{transform.position} {transform.localPosition}");
    }
}
