using UnityEngine;

public class SpellMove : MonoBehaviour
{
    [SerializeField] private Spell _spell;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _spell.Target.position, _spell.Speed * Time.deltaTime);
    }
}
