using UnityEngine;

public class ChestController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _requiredClicks = 3;
    [SerializeField] private float _clickDelay = 0.5f;

    [Header("Components")]
    [SerializeField] private Animator _animator;
    [SerializeField] private InteractionZone _interactionZone;

    private IClickSequenceHandler _clickHandler;
    private IChestState _chestState;

    private bool _canClicked;

    private void Awake()
    {
        _clickHandler = new ClickSequenceHandler(_requiredClicks, _clickDelay);
        _chestState = new ChestState(_animator);
    }

    private void OnEnable()
    {
        _interactionZone.OnInteractionStateChanged += HandleInteractionStateChange;
    }

    private void OnDisable()
    {
        _interactionZone.OnInteractionStateChanged -= HandleInteractionStateChange;
    }

    private void OnMouseDown()
    {
        if (_canClicked)
            if (_clickHandler.RegisterClick())
                _chestState.Open();
    }

    private void HandleInteractionStateChange(bool isActive)
    {
        _canClicked = isActive;

        _chestState.ToggleAnimationActivity(isActive);

        if (isActive == false) 
            _clickHandler.ResetSequence();
    }
}
