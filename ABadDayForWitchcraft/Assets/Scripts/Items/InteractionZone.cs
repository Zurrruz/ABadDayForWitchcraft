using System;
using UnityEngine;

public class InteractionZone : MonoBehaviour, IInteractionZone
{
    public event Action<bool> OnInteractionStateChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character _))
            OnInteractionStateChanged?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Character _))
            OnInteractionStateChanged?.Invoke(false);
    }
}
