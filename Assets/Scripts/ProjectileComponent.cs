using Arkanoid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileComponent : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float _speed;
        private float x;
        private float y;
        private float z;
        private Vector3 _lastVelocity;
        [SerializeField]
        private float _ricoсhetSpeed = 0.02f;
        [SerializeField]
        private bool _accelerationFromRicochet = true;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            x = Random.Range(-7, -9);
            y = Random.Range(-3, 3);
            z = Random.Range(-3, 3);
            Launch();
        }

        private void Launch()
        {
            _rigidbody.AddForce(new Vector3(x * _speed, y * _speed, z * _speed));
        }

        private void OnCollisionEnter(Collision collision)
        {
            var speed = _lastVelocity.magnitude;
            var direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);

            _rigidbody.velocity = direction * Mathf.Max(speed, 0f);
        }
        void FixedUpdate()
        {

            if (_accelerationFromRicochet)
            {
                _lastVelocity = _rigidbody.velocity * (_speed * _ricoсhetSpeed);
            }
            else
            {
                _lastVelocity = _rigidbody.velocity;
            }

        }
    }

}
