using UnityEngine;
using System.Collections;

public class BlockColor : MonoBehaviour
{
    private Renderer _renderer;
    private Block _block;

    private void Start()
    {
        _block = GetComponent<Block>();
        _renderer = GetComponent<Renderer>();
        float color = ((float)_block.Count - 1.0f) / (7.0f - 1.0f);

        _renderer.material.SetFloat("_Lerp", color);
    }
}
