using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private float _hMovement;
    private float _vMovement;
    [SerializeField] private float _moveSpeed = 2f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Movement();
        ApplyAnimations();
    }

    private void Movement()
    {
        _hMovement = Input.GetAxis("Horizontal");
        _vMovement = Input.GetAxis("Vertical");
        _rigidbody.velocity = new Vector2(_hMovement, _vMovement) * _moveSpeed;
    }

    private void ApplyAnimations()
    {
        if (_rigidbody.velocity.y > 0.1f)
        {
            _animator.Play("WalkUp");
        }
        else if (_rigidbody.velocity.y < -0.1f)
        {
            _animator.Play("WalkDown");
        }
        else if (_rigidbody.velocity.x > 0.1f)
        {
            _animator.Play("WalkRight");
        }
        else if (_rigidbody.velocity.x < -0.1f)
        {
            _animator.Play("WalkLeft");
        }
        else
        {
            _animator.Play("Idel");
        }
    }
}