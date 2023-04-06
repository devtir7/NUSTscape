using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCamera : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _difference;

    private Camera _mainCamera;

    private float _maxX = 29.5f, _maxY = 17.3f, _minX = -29f, _minY = -16.5f;
    private bool _isDragging;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) _origin = GetMousePosition;
        _isDragging = ctx.started || ctx.performed;
    }

    private void LateUpdate()
    {
        if (!_isDragging) return;

        _difference = GetMousePosition - transform.position;

        // transform.position = _origin - _difference;
        Vector3 newPos = _origin - _difference;
        transform.position = new Vector3(Mathf.Clamp(newPos.x, _minX, _maxX), Mathf.Clamp(newPos.y, _minY, _maxY),
            newPos.z);
    }
    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    private Vector3 GetMousePosition => GetWorldPositionOnPlane(Mouse.current.position.ReadValue());
    // private Vector3 GetMousePosition =>_mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
}