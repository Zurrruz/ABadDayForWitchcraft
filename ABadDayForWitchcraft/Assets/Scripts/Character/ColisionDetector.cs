using System;
using UnityEngine;

public class ColisionDetector : MonoBehaviour
{
    public event Action<ManaOrb> ManaOrbPicked;
    public event Action<CoinController> CoinPicked;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ManaOrb manaOrb))
            ManaOrbPicked?.Invoke(manaOrb);

        if (other.TryGetComponent(out CoinController coin))
            CoinPicked?.Invoke(coin);
    }
}
