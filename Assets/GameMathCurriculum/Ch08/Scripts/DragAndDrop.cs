using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera cam;
    public LayerMask ground;
    public LayerMask ball;
    public LayerMask dropZone;

    private bool isDraging = false;

    private Ball dragingObj;
    public Vector3 currentPos;


    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ball))
            {
                Debug.Log("Drag Start");
                isDraging = true;
                dragingObj = hit.collider.GetComponent<Ball>();
                dragingObj.DragStart();
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (isDraging)
            {
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, dropZone))
                {
                    dragingObj.DragEnd();
                }

                else
                {
                    dragingObj.Return();
                }

                isDraging = false;
                dragingObj = null;
            }
        }

        else if (isDraging)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ground))
            {
                dragingObj.transform.position = hit.point;
            }
        }
    }
}