using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private ColisionDetector _colisionDetector;

    public float CurrentCountCoins { get; private set; } = 0;

    private void OnEnable()
    {
        _colisionDetector.CoinPicked += AddCoin;
    }

    private void OnDisable()
    {
        _colisionDetector.CoinPicked -= AddCoin;
    }

    private void AddCoin(CoinController coin)
    {
        CurrentCountCoins += coin.Value;

        coin.Collect();
    }
}
