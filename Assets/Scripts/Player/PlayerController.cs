using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;

    private float _hMovement;
    private float _vMovement;
    private int _money;
    private int _health;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerData _playerData;

    public static Action<ItemObject> ChangeVisualTO;

    private void Awake()
    {
        _playerData = Resources.Load<PlayerData>("ScriptableData/PlayerData");
        if (_playerData == null)
        {
            Debug.Log("PlayerData is Null");
        }

        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        ChangeVisual(_playerData.PlayerVisual);
        _money = _playerData.Money;
        _health = _playerData.Health;
    }

    private void OnEnable()
    {
        ChangeVisualTO += ChangeVisual;
    }

    private void OnDisable()
    {
        ChangeVisualTO -= ChangeVisual;
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

    /// <summary>
    /// Apply Animations on the Player Visual
    /// </summary>
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

    /// <summary>
    /// Change the Visuals Prefab on the Player.
    /// </summary>
    private void ChangeVisual(ItemObject item)
    {
        _animator = null;
        Destroy(GetComponentInChildren<PlayerVisual>().gameObject);
        var visual = Instantiate(item.ItemPrefab, this.transform);
        _animator = visual.GetComponent<Animator>();
        _playerData.PlayerVisual = item;
    }
}