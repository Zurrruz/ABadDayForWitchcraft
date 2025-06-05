using UnityEngine;

public class ExplosionMagicEffect : IMagicEffect
{
    private readonly Vector3 _direction;
    private readonly float _force;

    public ExplosionMagicEffect(Vector3 direction, float force)
    {
        _direction = direction;
        _force = force;
    }

    public void Apply(Vector3 position, Rigidbody rb)
    {
        rb.AddForce(_direction * _force, ForceMode.Impulse);

        rb.AddTorque(Random.insideUnitSphere * _force * 0.1f, ForceMode.Impulse);
    }
}
