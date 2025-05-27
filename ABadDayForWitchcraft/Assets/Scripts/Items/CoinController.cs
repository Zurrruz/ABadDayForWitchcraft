using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int Value { get; private set; } = 1;

    public void Collect()
    {
        Destroy(gameObject);
    }
}
