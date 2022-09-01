using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField] private int _minCount = 1;
    [SerializeField] private int _maxCount = 10;
    public int Count = 1;
    [SerializeField] private TextMeshPro _countText;
    [SerializeField] private AudioSource _audio;

    private void Awake()
    {
        Count = Random.Range(_minCount, _maxCount + 1);
    }

    private void Start()
    {
        _countText.SetText(Count.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out SnakeTail segment))
              return;
        _audio.Play();
        int count = Count;
        Count -= segment.tailLenght;
        if (Count <= 0)
            Count = 0;
        
        _countText.SetText(Count.ToString());

        segment.RemoveSegment(count);

        if (Count <= 0)
        {
            Destroy(gameObject);
        }
    }
}
