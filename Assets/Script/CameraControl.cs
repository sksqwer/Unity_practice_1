using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera mainCamera;

    Vector3 defaultPosition;
    Quaternion defaultRotaion;
    float defaultZoom;

    // Start is called before the first frame update
    void Start()
    {


        mainCamera = transform.GetChild(0).GetComponent<Camera>();


        defaultZoom = mainCamera.fieldOfView;

        
    }

    // Update is called once per frame
    void Update()
    {
        defaultPosition = this.transform.position;
        defaultRotaion = this.transform.rotation;
        MoveCamera();
        RotateCamera();
        ZoomCamera();
        InitCamera();
    }

    private void InitCamera()
    {
        if(Input.GetMouseButton(2))
        {
            mainCamera.transform.position = defaultPosition;
            mainCamera.transform.rotation = defaultRotaion;
            mainCamera.fieldOfView = defaultZoom;
        }
    }

    private void ZoomCamera()
    {

        if (mainCamera.fieldOfView < 10)
        {
            mainCamera.fieldOfView = 10;
        }

        if (mainCamera.fieldOfView > 150)
        {
            mainCamera.fieldOfView = 150;
        }

        mainCamera.fieldOfView -= (20 * Input.GetAxisRaw("Mouse ScrollWheel"));
    }

    private void MoveCamera()
    {
        if (Input.GetMouseButton(0))
        {
            mainCamera.transform.Translate(Input.GetAxisRaw("Mouse X") / 3.0f, Input.GetAxisRaw("Mouse Y") / 3.0f, 0.0f);
        }
    }
    private void RotateCamera()
    {
        if (Input.GetMouseButton(1))
        {
            mainCamera.transform.rotation *= Quaternion.Euler(Input.GetAxisRaw("Mouse Y") *-10.0f, Input.GetAxisRaw("Mouse X") * 10.0f, 0.0f);
        }
    }
}
