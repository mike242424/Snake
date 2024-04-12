using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    void Start()
    {
        RandomizePostion();
    }

    void RandomizePostion()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new UnityEngine.Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
}