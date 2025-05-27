using System;

public interface IInteractionZone
{
    event Action<bool> OnInteractionStateChanged;
}
