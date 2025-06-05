using System;
using System.Collections;
using UnityEngine;

public class BridgeBlock : MonoBehaviour, IPoolableObject
{
    [SerializeField] private float _lifeTime = 10f;

    private Coroutine _lifeTimeCoroutine;
    private  Action<BridgeBlock> _returnToPoolAction;

    public void Initialize(Action<BridgeBlock> returnAction)
    {
        _returnToPoolAction = returnAction;
    }

    public void Activate(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
        gameObject.SetActive(true);

        if (_lifeTimeCoroutine != null)
            StopCoroutine(_lifeTimeCoroutine);

        _lifeTimeCoroutine = StartCoroutine(LifeTimeCountdown());
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        if (_lifeTimeCoroutine != null)
        {
            StopCoroutine(_lifeTimeCoroutine);
            _lifeTimeCoroutine = null;
        }
    }
    
    private IEnumerator LifeTimeCountdown()
    {
        yield return new WaitForSeconds(_lifeTime);
        _returnToPoolAction?.Invoke(this);
    }
}
