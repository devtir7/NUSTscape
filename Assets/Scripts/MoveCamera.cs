using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _originalPosition;
    private bool _drag = false;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _originalPosition = _camera.transform.position;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _difference = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, _camera.transform.position.z)) - _camera.transform.position;

            if (!_drag)
            {
                _drag = true;
                _origin = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y, _camera.transform.position.z));
            }
        }

        else
        {
            _drag = false;
        }

        if (_drag)
        {
            _camera.transform.position = _origin - _difference;
        }

        if (Input.GetMouseButton(1))
        {
            _camera.transform.position = _originalPosition;
        }
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}