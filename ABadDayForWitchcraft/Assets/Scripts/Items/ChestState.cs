using UnityEngine;

public class ChestState : IChestState
{
    private readonly Animator _animator;
    private bool _isOpened;

    public ChestState(Animator animator)
    {
        _animator = animator;
    }

    public void Open()
    {
        if (_isOpened)
            return;

        _animator.SetTrigger("Open");

        _isOpened = true;
    }

    public void Close()
    {
        if (_isOpened == false)
            return;

        _animator.SetTrigger("Close");

        _isOpened = false;
    }

    public void ToggleAnimationActivity(bool state)
    {
        if (_isOpened) 
            return;

        _animator.SetBool("Nearby", state);
    }
}
