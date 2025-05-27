using System;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Spell _spellPrefab;
    [SerializeField] private AttackButtonPlayer _attackButton;
    [SerializeField] private Transform _castPoint;

    public event Action Attacked;

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
        //реализовать каст с обрывом каста при движении

        Spell spell =  Instantiate(_spellPrefab, _castPoint);
        spell.transform.SetParent(null);
        spell.SpecifyGoal(_enemy.transform);

        Attacked?.Invoke();

        DealDamage();
    }

    private void DealDamage()
    {
        //реализовать нанесение урона врагу
    }
}
