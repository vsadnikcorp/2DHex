using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKeyBoardController : MonoBehaviour
{
    float moveSpeed = 15f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 moveCamera = new Vector3
      (
          Input.GetAxis("Horizontal"),
          Input.GetAxis("Vertical")
      );
        Camera.main.transform.Translate(moveCamera * moveSpeed * Time.deltaTime, Space.World);
    }
}
