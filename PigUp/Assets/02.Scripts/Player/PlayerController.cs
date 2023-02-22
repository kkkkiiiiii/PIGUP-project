using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    public float speed=1;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _move;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // 1. Input Value
        float x = floatingJoystick.Horizontal;
        float z = floatingJoystick.Vertical;
        // 2. Move Position
        _move = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + _move);
        if (_move.sqrMagnitude == 0)
            return;
        // 3. Move Rotation
        Quaternion dirQuaternion = Quaternion.LookRotation(_move);
        Quaternion moveQuaternion = Quaternion.Slerp(_rigidbody.rotation,dirQuaternion,0.1f);
        _rigidbody.MoveRotation(moveQuaternion);
    }
}
