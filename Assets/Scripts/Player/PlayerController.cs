using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;

    private bool _canMove;
    private Vector2 _moveVector;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerData _playerData;
    public static Action<ItemObject> ChangeVisualTO;

    private void Awake()
    {
        _playerData = Resources.Load<PlayerData>("ScriptableData/Data/PlayerData");
        if (_playerData == null)
        {
            Debug.LogWarning("PlayerData is Null");
        }

        CanPlayerMove(false);
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        ChangeVisual(_playerData.PlayerVisual);
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
        if (_canMove)
        {
            _moveVector.x = Input.GetAxis("Horizontal");
            _moveVector.y = Input.GetAxis("Vertical");
        }
        else
        {
            _moveVector = Vector2.zero;
        }

        Movement();
        ApplyAnimations();
    }

    private void Movement()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveVector.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Apply Animations on the Player Visual
    /// </summary>
    private void ApplyAnimations()
    {
        if (_moveVector.y > 0.1f)
        {
            _animator.Play("WalkUp");
        }
        else if (_moveVector.y < -0.1f)
        {
            _animator.Play("WalkDown");
        }
        else if (_moveVector.x > 0.1f)
        {
            _animator.Play("WalkRight");
        }
        else if (_moveVector.x < -0.1f)
        {
            _animator.Play("WalkLeft");
        }
        else if (_moveVector.y < 0.1f || _moveVector.y > -0.1f || _moveVector.x > -0.1f ||
                 _moveVector.x < 0.1f)
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

    public void CanPlayerMove(bool value)
    {
        _canMove = value;
    }
}