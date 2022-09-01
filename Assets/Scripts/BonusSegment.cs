using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BonusSegment : MonoBehaviour
{
    [SerializeField] private int _count = 1;
    [SerializeField] private int _minCount = 1;
    [SerializeField] private int _maxCount = 5;

    [SerializeField] private TextMeshPro _text;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private ParticleSystem _particle;

    private void Start()
    {
        _count = Random.Range(_minCount, _maxCount);
        _text.SetText(_count.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeTail segment))
        {
            _particle.Play();
            _audio.Play();
            segment.AddSegment(_count);
            Destroy(gameObject,0.1f);
        }
    }
}
