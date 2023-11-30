using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public Camera arCamera;
    public GameObject prismPanel;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                Debug.Log("Raycast envoyé");

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("Prisme"))
                    {
                        Debug.Log("Raycast a touché: " + hitObject.collider.gameObject.name);
                        prismPanel.SetActive(true);
                    }
                    else
                    {
                        
                        prismPanel.SetActive(false);
                    }
                }
            }
        }
    }
}
