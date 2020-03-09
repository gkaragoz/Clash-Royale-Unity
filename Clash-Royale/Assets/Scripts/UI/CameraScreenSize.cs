using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenSize : MonoBehaviour
{
    public SpriteRenderer area;
    void Start()
    {


    }


    private void Update()
    {
        SetSizeCamera();
    }
    public void SetSizeCamera()
    {

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = area.bounds.size.x / area.bounds.size.y;
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = area.bounds.size.y / 2;

        }
        else
        {
            float difference = targetRatio / screenRatio;
            Camera.main.orthographicSize = area.bounds.size.y / 2 * difference;
        }


    }
}



