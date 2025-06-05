using System.Collections;
using UnityEngine;

public class BridgeGenerator : MonoBehaviour
{
    [Header("Настройки генерации")]
    [SerializeField] private BridgeBlock _bridgeBlockPrefab;
    [SerializeField] private int _poolSize = 20;
    [SerializeField] private float _generationInterval = 1f;
    [SerializeField] private float _blockLength = 1f;
    [SerializeField] private Vector3 _generationDirection = Vector3.forward;

    private BridgeBlockPool _blockPool;
    private Vector3 _nextPosition;
    private bool _isGenerating;

    private void Awake()
    {
        _blockPool = new BridgeBlockPool(_bridgeBlockPrefab, transform, _poolSize);
        _nextPosition = transform.position;
    }

    private void Start()
    {
        StartGeneration();
    }

    private void StartGeneration()
    {
        if (_isGenerating) 
            return;

        _isGenerating = true;
        StartCoroutine(GenerationProcess());
    }

    private IEnumerator GenerationProcess()
    {
        WaitForSeconds timeout = new(_generationInterval);

        while (_isGenerating)
        {
            GenerateNextBlock();

            yield return timeout;
        }
    }

    private void GenerateNextBlock()
    {
        var block = _blockPool.GetBlock();
        block.Activate(_nextPosition, Quaternion.LookRotation(_generationDirection));

        _nextPosition -= _generationDirection.normalized * _blockLength;
    }
}
