using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenSize : MonoBehaviour
{

    private Camera _cam;
    void Start()
    {

        _cam = Camera.main;
        SetSizeCamera();
    }



    public void SetSizeCamera()
    {

        if (_cam.aspect <= 0.48f)
        {
            _cam.orthographicSize = 14.75f;

        }
        else if (_cam.aspect <= 0.51f)
        {
            _cam.orthographicSize = 14f;

        }
        else if (_cam.aspect <= 0.57f)
        {
            _cam.orthographicSize = 12.5f;

        }
        else if (_cam.aspect <= 0.76f)
        {
            _cam.orthographicSize = 12f;

        }


    }
}



