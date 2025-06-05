using System;
using UnityEngine;

public interface IInputService
{
    public event Action OnDragStarted;
    public event Action<Vector3[]> OnDragEndedWithPath;

    void Tick();
}
