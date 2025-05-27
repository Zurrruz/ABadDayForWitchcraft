using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _speed;

    public float Damage => _damage;
    public float Speed => _speed;
    public Transform Target { get; private set; }

    public void SpecifyGoal(Transform target)
    {
        Target = target;
    }
}
