using System;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputService : IInputService
{
    public event Action OnDragStarted;
    public event Action<Vector3[]> OnDragEndedWithPath;

    private bool _isDragging;
    private readonly List<Vector3> _mousePath = new();

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _mousePath.Clear();
            _mousePath.Add(Input.mousePosition);
            OnDragStarted?.Invoke();
        }

        if (Input.GetMouseButtonUp(0) && _isDragging)
        {
            _isDragging = false;
            OnDragEndedWithPath?.Invoke(_mousePath.ToArray());
        }

        if (_isDragging)
        {
            _mousePath.Add(Input.mousePosition);
        }
    }
}