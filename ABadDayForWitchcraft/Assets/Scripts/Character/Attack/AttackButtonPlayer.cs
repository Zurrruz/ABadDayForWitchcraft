using UnityEngine;
using UnityEngine.UI;
using System;

public class AttackButtonPlayer : MonoBehaviour
{
    [SerializeField] private PlayerMana _playerMana;
    [SerializeField] private Button _button;

    public event Action Ñlicked;

    private void Awake()
    {
        _button.interactable = true;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnAttackButtonClick);
        _playerMana.Changed += ChangeState;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAttackButtonClick);
        _playerMana.Changed -= ChangeState;
    }

    private void ChangeState(float currentMana, float maxMana)
    {
        if(currentMana == maxMana)
            _button.interactable = true;
    }

    private void OnAttackButtonClick()
    {
        Ñlicked?.Invoke();

        _button.interactable = false;
    }
}
