using UnityEngine;

public interface IPoolableObject
{
    void Activate(Vector3 position, Quaternion rotation);
    void Deactivate();
}
