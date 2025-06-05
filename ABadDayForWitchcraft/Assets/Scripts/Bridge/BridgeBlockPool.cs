using System.Collections.Generic;
using UnityEngine;

public class BridgeBlockPool
{
    private readonly BridgeBlock _prefab;
    private readonly Transform _transform;
    private readonly Queue<BridgeBlock> _pool = new();
    private readonly List<BridgeBlock> _activeBlocks = new();

    public BridgeBlockPool(BridgeBlock prefab, Transform transform, int initialSize)
    {
        _prefab = prefab;
        _transform = transform;

        for (int i = 0; i < initialSize; i++)
            CreateNewBlock();
    }

    public BridgeBlock GetBlock()
    {
        if (_pool.Count == 0)
            CreateNewBlock();

        var block = _pool.Dequeue();
        _activeBlocks.Add(block);

        return block;
    }

    public void ReturnBlock(BridgeBlock block)
    {
        block.Deactivate();
        _activeBlocks.Remove(block);
        _pool.Enqueue(block);
    }

    private void CreateNewBlock()
    {
        var gameobject = Object.Instantiate(_prefab, _transform);

        if (gameobject.TryGetComponent(out BridgeBlock block))
        {
            block.Initialize(ReturnBlock);
            block.Deactivate();
            _pool.Enqueue(block);
        }
    }
}
