using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float Sensitivity = 10f;

    [SerializeField] private SnakeTail _snakeTail;
    private Transform _snakeTransform;

    private void Start()
    {
        _snakeTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        _snakeTransform.position += _snakeTransform.forward * Speed * Time.deltaTime;

        if (transform.position.x >= 7f)
        {
            transform.position = new Vector3(7f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -7f)
        {
            transform.position = new Vector3(-7f, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _snakeTransform.position += -_snakeTransform.right * Sensitivity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _snakeTransform.position += _snakeTransform.right * Sensitivity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _snakeTail.RemoveSegment(1);

        }
    }
}
