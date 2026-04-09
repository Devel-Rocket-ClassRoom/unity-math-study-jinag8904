using UnityEngine;
using UnityEngine.UI;

public class IndicatorViewer : MonoBehaviour
{
    public Camera cam;
    public Transform[] targets;
    public Image[] indicators;

    float xPos;
    float yPos;

    private void LateUpdate()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            Vector2 screenCenter = screenSize * 0.5f;

            var screenPoint = cam.WorldToScreenPoint(targets[i].position);
            xPos = screenPoint.x;
            yPos = screenPoint.y;

            // 화면 안
            if (screenPoint.x >= 0 && screenPoint.x <= screenSize.x && 
                screenPoint.y >= 0 && screenPoint.y <= screenSize.y && 
                screenPoint.z >= 0)
            {
                indicators[i].enabled = false;
            }

            // 화면 밖
            else 
            {
                if (screenPoint.z < 0)  // 카메라 뒤
                {
                    xPos = screenCenter.x - xPos;
                    yPos = screenCenter.y - yPos;
                }

                indicators[i].enabled = true;
            }

            xPos = Mathf.Clamp(xPos, 0, screenSize.x);
            yPos = Mathf.Clamp(yPos, 0, screenSize.y);

            indicators[i].rectTransform.position = new Vector3(xPos, yPos);
            //indicators[i].rectTransform.anchoredPosition = new Vector3(xPos, yPos);
        }
    }
}
