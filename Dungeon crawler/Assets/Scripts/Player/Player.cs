using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;

    [SerializeField]
    private float _jumpForce = 2.0f;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private float _speed = 5.0f;
    private bool _grounded = false;
    private Rigidbody2D _rigid;
    private bool _resetJump = false;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordSprite;

    public int Health { get; set; }

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnimation.Attack();
        }
    }

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        Flip(move);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJump());
            _playerAnimation.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnimation.Move(Mathf.Abs(move));
    }

    private void Flip(float move)
    {
        if (move > 0)
        {
            _sprite.flipX = false;
            _swordSprite.flipX = false;
            _swordSprite.flipY = false;

            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordSprite.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            _sprite.flipX = true;
            _swordSprite.flipX = true;
            _swordSprite.flipY = true;

            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordSprite.transform.localPosition = newPos;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, _groundLayer.value);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJump()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            _playerAnimation.Death();
        }
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }
}
