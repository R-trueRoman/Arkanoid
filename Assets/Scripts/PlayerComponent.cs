using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerComponent : MonoBehaviour
{
    [SerializeField]
    private float _moveSide;
    [SerializeField]
    private Rigidbody _rigidbody;
    private Vector3 _moveVelocity;
    void Start()
    {
        
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(default, Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        _moveVelocity = moveInput.normalized * _moveSide;
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
    }

}
