using UnityEngine;

public class MovementHandler
{
    private readonly CharacterController _controller;
    private readonly float _moveSpeed;
    private readonly float _rotationSpeed = 10f;

    public MovementHandler(CharacterController controller, float moveSpeed, float stepHeight)
    {
        _controller = controller;
        _moveSpeed = moveSpeed;
        _controller.stepOffset = stepHeight;
    }

    public void Move(Vector2 input, Transform transform)
    {
        Vector3 direction = new Vector3(input.x, 0, input.y).normalized;

        if (direction.magnitude > 0.1f)
        {
            _controller.Move(direction * _moveSpeed * Time.deltaTime);
            RotateTowards(direction, transform);
        }
    }

    private void RotateTowards(Vector3 direction, Transform transform)
    {
        direction = Quaternion.Euler(0, 180f, 0) * direction;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * _rotationSpeed
        );
    }
}
