using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _stepHeight = 0.3f;
    [SerializeField] private float _fallMultiplier = 2f;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    private IMovementInput _movementInput;
    private GravityHandler _gravityHandler;
    private MovementHandler _movementHandler;

    private bool _isMoving;
    private bool _wasMovingLastFrame;

    public event Action<bool> OnMovementStateChanged;

    private void Awake()
    {
        _movementInput = new KeyboardMovementInput();

        CharacterController controller = GetComponent<CharacterController>();

        _gravityHandler = new GravityHandler(
            controller, _groundCheck, _groundDistance, _groundMask, _gravity, _fallMultiplier);

        _movementHandler = new MovementHandler(
            controller, _moveSpeed, _stepHeight);
    }

    private void Update()
    {
        _gravityHandler.UpdateGravity();

        Vector2 input = _movementInput.GetMovementInput();

        _movementHandler.Move(input, transform);

        _isMoving = input.magnitude > 0.1f;

        if (_isMoving != _wasMovingLastFrame)
        {
            OnMovementStateChanged?.Invoke(_isMoving);
            _wasMovingLastFrame = _isMoving;
        }
    }
}
