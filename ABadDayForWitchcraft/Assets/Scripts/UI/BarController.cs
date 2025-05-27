using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _updateSpeed;

    private float _targetValue;

    private void Start()
    {
        _slider.value = 0;
    }

    protected void Change(float currentValue, float maxValue)
    {
        _targetValue = currentValue / maxValue;

        _slider.DOValue(_targetValue, _updateSpeed).SetEase(Ease.OutQuad);
    }
}
