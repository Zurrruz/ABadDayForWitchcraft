using UnityEngine;

public class ClickSequenceHandler : IClickSequenceHandler
{
    private readonly int _requiredClicks;
    private readonly float _clickDelay;

    private int _currentClicks;
    private float _lastClickTime;

    public ClickSequenceHandler(int requiredClicks, float clickDelay)
    {
        _requiredClicks = requiredClicks;
        _clickDelay = clickDelay;
    }

    public bool RegisterClick()
    {
        if (Time.time - _lastClickTime > _clickDelay)
            ResetSequence();

        _currentClicks++;
        _lastClickTime = Time.time;

        return _currentClicks >= _requiredClicks;
    }

    public void ResetSequence()
    {
        _currentClicks = 0;
    }
}