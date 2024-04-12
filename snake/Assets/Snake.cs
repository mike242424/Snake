using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private UnityEngine.Vector2 _direction = UnityEngine.Vector2.left;
    private List<Transform> _segments;
    public Transform segmentPrefab;

    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = UnityEngine.Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = UnityEngine.Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = UnityEngine.Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = UnityEngine.Vector2.right;
        }
    }

    void FixedUpdate()
    {
        transform.position = new UnityEngine.Vector3(Mathf.Round(transform.position.x) + _direction.x, Mathf.Round(transform.position.y) + _direction.y, 0.0f);
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
    }
}
