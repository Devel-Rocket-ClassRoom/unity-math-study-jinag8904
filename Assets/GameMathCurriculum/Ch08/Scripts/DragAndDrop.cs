using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera cam;
    private Ball selectedObject;

    public Vector3 currentPos;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))    // 좌클릭
        {
            // 들고 있을 때
            if (selectedObject != null)
            {
                var rayCastHits = Physics.RaycastAll(ray);  // 닿은 애들 전부 저장

                foreach (var hit in rayCastHits)
                {
                    if (hit.collider.CompareTag("DropZone"))
                    {
                        OnDropZone();
                        break;
                    }

                    else if (hit.collider.CompareTag("Ground"))
                    {
                        OnGround();
                        break;
                    }
                }
            }

            // 안 들고 있을 때
            else
            {
                var rayCastHits = Physics.RaycastAll(ray);  // 닿은 애들 전부 저장

                foreach (var hit in rayCastHits)
                {
                    if (hit.collider.CompareTag("Selectable"))
                    {
                        selectedObject = hit.collider.gameObject.GetComponent<Ball>();
                        break;
                    }
                }
            }
        }
        else
        {
            // 들고 있을 때, 오브젝트 움직이기
            if (selectedObject != null)
            {
                var rayCastHits = Physics.RaycastAll(ray);  // 닿은 애들 전부 저장

                foreach (var hit in rayCastHits)
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        currentPos = new Vector3(hit.point.x, hit.point.y + 12.5f, hit.point.z);
                        break;
                    }
                }

                selectedObject.transform.position = currentPos;
            }
        }
    }

    private void OnDropZone()
    {
        Debug.Log("OnDropZone() 실행");
        selectedObject.transform.position = new Vector3(currentPos.x, currentPos.y + 10f, currentPos.z);
        selectedObject = null;
    } 

    private void OnGround()
    {
        Debug.Log("OnGround() 실행");
        selectedObject = null;
    }
}
