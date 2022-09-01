using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private GameObject _headPosition;
    [SerializeField] private GameObject _segment;
    [SerializeField] private TextMeshPro PointsText;
    [SerializeField] private Game _game;

    [SerializeField] private List<GameObject> _tails = new List<GameObject>();
    [SerializeField] private List<Vector3> _positions = new List<Vector3>();


    private float _segmentDiametr = 1f;
    public int tailLenght = 1;
    void Start()
    {
        _positions.Add(_headPosition.transform.position);
        PointsText.SetText(tailLenght.ToString());
    }

    void Update()
    {
        float distance = (_headPosition.transform.position - _positions[0]).magnitude;
        if (distance > _segmentDiametr)
        {
            Vector3 direction = (_headPosition.transform.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0] + direction * _segmentDiametr);
            _positions.RemoveAt(_positions.Count - 1);

            distance -= _segmentDiametr;
        }

        for (int i = 0; i < _tails.Count; i++)
        {
            _tails[i].transform.position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / _segmentDiametr);
        }
    }

    public void AddSegment(int count)
    {
        tailLenght += count;

        for (int i = 0; i < count; i++)
        {
            GameObject newSegment = Instantiate(_segment, _positions[_positions.Count - 1], Quaternion.identity, transform);
            newSegment.transform.position = new Vector3(_headPosition.transform.position.x, _headPosition.transform.position.y,
                _positions[_positions.Count - 1].z - _segmentDiametr);

            _positions.Add(newSegment.transform.position);
            _tails.Add(newSegment);
        }
        PointsText.SetText(tailLenght.ToString());
    }

    public void RemoveSegment(int count)
    {
        tailLenght -= count;
        if (tailLenght <= 0)
        {
            tailLenght = 0;
            _game.OnPlayerDied();
        }
        PointsText.SetText(tailLenght.ToString());

        for (int i = count - 1; i >= 0 ; i--)
        {
            Destroy(_tails[i]);
            _tails.Remove(_tails[i]);
            _positions.Remove(_positions[i + 1]);
        }
    }

    public void ReachedFinish()
    {
        _game.OnPlayerReachFinish();
    }
}
