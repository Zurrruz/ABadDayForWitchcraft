using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private MagicDestructionController _magicController;

    private void Update()
    {
        _magicController.SystemUpdate();
    }
}
