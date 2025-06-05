using UnityEngine;

public class AnimationPlaybackTime
{
    private readonly Animator _animator;
    private readonly AnimationClip _castAnimation;
    private float _castTimeMultiplier = 1;

    public AnimationPlaybackTime(Animator animator, AnimationClip castAnimation)
    {
        _animator = animator;
        _castAnimation = castAnimation;
    }

    public void SetTimerCastClip(string trigger, float customDuration)
    {
        _castTimeMultiplier = _castAnimation.length / customDuration;

        _animator.SetFloat("CastSpeed", _castTimeMultiplier);

        _animator.SetTrigger(trigger);
    }
}
