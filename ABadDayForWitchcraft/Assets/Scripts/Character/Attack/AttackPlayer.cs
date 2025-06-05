using System;
using System.Collections;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Spell _spellPrefab;
    [SerializeField] private AttackButtonPlayer _attackButton;
    [SerializeField] private Transform _castPoint;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _castSpeed;

    private WaitForSeconds _delayTime;
    private Coroutine _delayCasting;

    public event Action<float> Attacked;

    private void Awake()
    {
        _delayTime = new(_castSpeed);
    }

    private void OnEnable()
    {
        _attackButton.Сlicked += Cast;
    }

    private void OnDisable()
    {
        _attackButton.Сlicked -= Cast;
    }

    private void Cast()
    {
        _delayCasting = StartCoroutine(Delay());

        Attacked?.Invoke(_castSpeed);        
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.05f);

        Spell spell = Instantiate(_spellPrefab, _castPoint);
        spell.transform.SetParent(null);
        spell.SpecifyGoal(_enemy.transform);

        DealDamage();
    }

    private void CastBreakage()
    {
        if(_delayCasting != null) 
            StopCoroutine(_delayCasting);
    }

    private void DealDamage()
    {
        //реализовать нанесение урона врагу
    }
}
