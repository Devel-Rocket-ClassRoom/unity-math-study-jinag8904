using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera cam;
    private GameObject selectedObject;

    public Terrain terrain;
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
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("DropZone"))
                    {
                        OnDropZone();
                    }

                    else if (hit.collider.CompareTag("Ground"))

                    {
                        OnGround();
                    }
                }
            }

            // 안 들고 있을 때
            else
            {
                // Selectable 위인지 아닌지
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Selectable"))
                    {
                        selectedObject = hit.collider.gameObject;
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
        selectedObject.transform.position = new Vector3(currentPos.x, currentPos.y + 10f, currentPos.z); ;
        selectedObject = null;
    }

    private void OnGround()
    {
        selectedObject = null;
    }
}
