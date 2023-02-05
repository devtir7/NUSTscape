using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchAndZoom : MonoBehaviour
{
    private float _maxZoom = -8.5f;
    private float _minZoom=-17f;

    private const float TouchZoomSpeed = 0.5f;

    private const float MouseZoomSpeed = 30f;

    void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {
                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);
            }
        }
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
                Zoom(scroll, MouseZoomSpeed);
        }
    }

    private void Zoom(float deltaMagnitudeDiff, float speed)
    {
        float newZ = Mathf.Clamp(-deltaMagnitudeDiff * speed +transform.position.z, _minZoom, _maxZoom);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}