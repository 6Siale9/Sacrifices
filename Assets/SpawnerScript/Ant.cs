using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _mass = 0f;
    [SerializeField] private Rigidbody _rigidBody = null;
    [SerializeField] private float _size = 0;

    public float Size { get => _size; set => _size = value; }

    void Start()
    {
        _rigidBody.velocity = Vector3.forward.normalized * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
