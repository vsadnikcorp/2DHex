using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseController : MonoBehaviour
{
    Vector2 lastFramePosition;
    private float zoomSpeed = 10.0f;
    private float minOrtho = 2.0f;
    private float maxOrtho = 30.0f;

    void Start()
    {
    }

    void Update()
    {
        Vector2 currentFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        //HANDLE SCREEN DRAGGING
        if (Input.GetMouseButton(1)) //RIGHT MOUSE BUTTON
        {
            Vector2 delta = lastFramePosition - currentFramePosition;
            Camera.main.transform.Translate(delta);
        }
        lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //HANDLE ZOOMING WITH MOUSE WHEEL
        //TODO: DISTINCT ZOOM LEVELS?
        /*
        if (scroll != 0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, zoomSpeed * Time.deltaTime);
        //Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetOrtho, zoomSpeed * Time.deltaTime);
        */
        //float f = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 V3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.orthographicSize += zoomSpeed * scroll;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize,
                minOrtho, maxOrtho);
            V3 = V3 - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += V3;
        }

        //CENTER MAP ON RIGHT MOUSE CLICK
        //TODO
        if (Input.GetKey(KeyCode.LeftShift) == true || Input.GetKey(KeyCode.RightShift) == true)
        {
           
            if(Input.GetMouseButtonDown(1))
            {
                //TODO
            }
        }

    }
}
