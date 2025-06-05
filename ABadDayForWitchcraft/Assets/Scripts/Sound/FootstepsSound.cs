using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepsSound : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _stepInterval = 0.5f;

    private AudioSource _audioSource;

    private Coroutine _playClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _playerMovement.OnMovementStateChanged += Changed;
    }

    private void OnDisable()
    {
        _playerMovement.OnMovementStateChanged -= Changed;
    }

    private void Changed(bool isMove)
    {      
        if (isMove) 
            _playClip = StartCoroutine(Play(_stepInterval));
        else if (_playClip != null) 
            StopCoroutine(_playClip);
    }

    private IEnumerator Play(float stepTime)
    {
        WaitForSeconds nextStepTime = new(stepTime);

        while(enabled)
        {
            _audioSource.PlayOneShot(_clip);
            yield return nextStepTime;
        }
    }
}
