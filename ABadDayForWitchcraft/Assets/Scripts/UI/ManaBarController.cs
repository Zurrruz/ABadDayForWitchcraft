using UnityEngine;

public class ManaBarController : BarController
{
    [SerializeField] private PlayerMana _playerMana;

    private void OnEnable()
    {
        _playerMana.Changed += Change;
    }

    private void OnDisable()
    {
        _playerMana.Changed -= Change;
    }
}
