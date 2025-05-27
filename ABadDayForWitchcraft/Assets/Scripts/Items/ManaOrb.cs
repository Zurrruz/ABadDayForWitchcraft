using UnityEngine;

public class ManaOrb : MonoBehaviour
{
    public int Value { get; private set; } = 20;

    public void Collect()
    {
        Destroy(gameObject);
    }
}
