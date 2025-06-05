using UnityEngine;

public class MagicDestructionController : MonoBehaviour
{
    [SerializeField] private LayerMask _destructibleLayer;
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _destructionRadius = 1.5f;

    private IInputService _inputService;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _inputService = new MouseInputService();
    }

    private void OnEnable()
    {
        _inputService.OnDragEndedWithPath += OnDragEndWithPath;
    }

    private void OnDisable()
    {
        _inputService.OnDragEndedWithPath -= OnDragEndWithPath;
    }

    private void OnDragStart()
    {
        // добавить визуальный эффект "накопления магии"
    }

    private void OnDragEndWithPath(Vector3[] mousePath)
    {
        if (mousePath.Length < 2) return;

        Vector3 screenDirection = (mousePath[^1] - mousePath[0]).normalized;
        Vector3 worldDirection = _mainCamera.transform.TransformDirection(screenDirection);

        foreach (var mousePos in mousePath)
        {
            Ray currentRay = _mainCamera.ScreenPointToRay(mousePos);
            RaycastHit[] hits = Physics.SphereCastAll(currentRay, _destructionRadius, 100f, _destructibleLayer);

            foreach (var hit in hits)
            {
                if (hit.collider.TryGetComponent<IDestructible>(out var destructible))
                {                    
                    Vector3 explosionDir = (worldDirection + (hit.point - currentRay.origin).normalized).normalized;
                    var effect = new ExplosionMagicEffect(explosionDir, _explosionForce);
                    destructible.Destruct(effect);
                }
            }
        }
    }

    public void SystemUpdate()
    {
        _inputService.Tick();
    }
}
