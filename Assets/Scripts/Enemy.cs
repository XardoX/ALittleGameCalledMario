using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;

    private void Update()
    {
        var dir = Vector3.right;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
