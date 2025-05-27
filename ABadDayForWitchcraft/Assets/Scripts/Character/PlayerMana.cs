using System;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100f;
    [SerializeField] private ColisionDetector _colisionDetector;
    [SerializeField] private AttackPlayer _attackPlayer;

    private float _currentMana = 0;

    public event Action<float, float> Changed;

    private void OnEnable()
    {
        _colisionDetector.ManaOrbPicked += Add;
        _attackPlayer.Attacked += Spend;
    }

    private void OnDisable()
    {
        _colisionDetector.ManaOrbPicked -= Add;
        _attackPlayer.Attacked -= Spend;
    }

    private void Add(ManaOrb manaOrb)
    {
        _currentMana = Mathf.Min(_currentMana + manaOrb.Value, _maxValue);

        Changed?.Invoke(_currentMana, _maxValue);

        manaOrb.Collect();
    }

    private void Spend()
    {
        _currentMana = 0;

        Changed?.Invoke(_currentMana, _maxValue);
    }
}
