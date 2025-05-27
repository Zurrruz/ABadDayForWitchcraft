using UnityEngine;

public class ChestController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _requiredClicks = 3;
    [SerializeField] private float _clickDelay = 0.5f;

    [Header("Components")]
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _interactionZone;

    private IClickSequenceHandler _clickHandler;
    private IChestState _chestState;
    private IInteractionZone _zone;

    private void Awake()
    {
        _clickHandler = new ClickSequenceHandler(_requiredClicks, _clickDelay);
        _chestState = new ChestState(_animator);

        _zone = _interactionZone.AddComponent<InteractionZone>();
        _zone.OnInteractionStateChanged += HandleInteractionStateChange;
    }

    private void OnMouseDown()
    {
        if (_clickHandler.RegisterClick())
            _chestState.Open();

    }

    private void HandleInteractionStateChange(bool isActive)
    {
        _chestState.ToggleAnimationActivity(isActive);

        if (isActive == false) 
            _clickHandler.ResetSequence();
    }

    private void OnDestroy()
    {
        if (_zone != null)
            _zone.OnInteractionStateChanged -= HandleInteractionStateChange;
    }
}
