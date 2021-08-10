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

        //Calling this here so on restart the player get the visual they have equipped.
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
            // if the player cannot move make this movement null as he will slide on the map without players control.
            _moveVector = Vector2.zero;
        }

        Movement();
        ApplyAnimations();
    }

    private void Movement()
    {
        //Right now this works but the movement is still sloppy which can be improved if done with getting button inputs
        //or done with Transform rather then physics i.e rigidbody.
        _rigidbody.MovePosition(_rigidbody.position + _moveVector.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Apply Animations on the Player Visual
    /// </summary>
    private void ApplyAnimations()
    {
        // setting animation directly in code as 2d animations can feel snappy rather
        // then fiddling around with the macanim animation settings
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

    /// <summary>
    /// Sets if the player can move or not.
    /// </summary>
    /// <param name="value">bool value</param>
    public void CanPlayerMove(bool value)
    {
        _canMove = value;
    }
}