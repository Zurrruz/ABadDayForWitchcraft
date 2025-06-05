using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AttackPlayer _attackPlayer;
    [SerializeField] private AnimationClip _castClip;

    private AnimationPlaybackTime _animationPlaybackTime;
    private Animator _animator;
    private const string IsRunningParam = "IsRunning";
    private const string CastTrigger = "Cast";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animationPlaybackTime = new(_animator, _castClip);
    }

    private void OnEnable()
    {
        _playerMovement.OnMovementStateChanged += SetMovementState;
        _attackPlayer.Attacked += StartCasting;
    }

    private void OnDisable()
    {
        _playerMovement.OnMovementStateChanged -= SetMovementState;
        _attackPlayer.Attacked -= StartCasting;
    }

    private void SetMovementState(bool isRunning)
    {
        _animator.SetBool(IsRunningParam, isRunning);
    }

    private void StartCasting(float time)
    {
        _animationPlaybackTime.SetTimerCastClip(CastTrigger, time);
    }
}