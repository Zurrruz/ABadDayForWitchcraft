using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestructibleBlock : MonoBehaviour, IDestructible
{
    [SerializeField] private float _destroyDelay = 1f;
    [SerializeField] private ParticleSystem _destructionEffect;
    [SerializeField] private InteractionZone _interactionZone;

    private Rigidbody _rigidbody;
    private bool _isActive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _interactionZone.OnInteractionStateChanged += ChangeActive;
    }

    private void OnDisable()
    {
        _interactionZone.OnInteractionStateChanged -= ChangeActive;
    }

    private void ChangeActive(bool isActive)
    {
        _isActive = isActive;
    }

    public void Destruct(IMagicEffect effect)
    {
        if (_rigidbody == null) 
            return;

        if (_isActive)
        {
            effect.Apply(transform.position, _rigidbody);

            // добавить визуальные эффекты. ну или не добавлять
            if (_destructionEffect != null)
            {
                Instantiate(_destructionEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject, _destroyDelay);

            enabled = false;
        }
    }
}
