using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private UnityEngine.Vector2 _direction = UnityEngine.Vector2.left;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 1;

    void Start()
    {
        ResetState();
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
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        transform.position = new UnityEngine.Vector3(Mathf.Round(transform.position.x) + _direction.x, Mathf.Round(transform.position.y) + _direction.y, 0.0f);
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(transform);

        for (int i = 1; i < initialSize; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }

        transform.position = UnityEngine.Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
