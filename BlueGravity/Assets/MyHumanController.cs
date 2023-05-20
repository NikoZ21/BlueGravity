using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHumanController : MonoBehaviour
{
    [SerializeField] private GameObject frontHuman;
    [SerializeField] private GameObject backHuman;
    [SerializeField] private GameObject leftHuman;
    [SerializeField] private GameObject rightHuman;

    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    private readonly int _idleAnimationId = Animator.StringToHash("Idle");
    private readonly int _walkAnimationId = Animator.StringToHash("Walk");

    private GameObject _currentHuman;
    private Rigidbody2D _rb;
    private Vector2 _moveMent;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentHuman = frontHuman;
        _currentHuman.SetActive(true);
    }

    void Update()
    {
        _moveMent.x = Input.GetAxisRaw("Horizontal");
        _moveMent.y = Input.GetAxisRaw("Vertical");

        if (IsMoving()) return;

        animator.CrossFade(_idleAnimationId, 0, 0);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveMent * Time.fixedDeltaTime * speed);
    }


    private bool IsMoving()
    {
        if (_moveMent == Vector2.zero) return false;

        animator.CrossFade(_walkAnimationId, 0, 0);

        if (_moveMent.x > 0)
        {
            if (_currentHuman == rightHuman) return true;

            UpdateHumanState(rightHuman);
            return true;
        }

        if (_moveMent.x < 0)
        {
            if (_currentHuman == leftHuman) return true;

            UpdateHumanState(leftHuman);
            return true;
        }

        if (_moveMent.y > 0)
        {
            if (_currentHuman == backHuman) return true;

            UpdateHumanState(backHuman);
            return true;
        }

        if (_moveMent.y < 0)
        {
            if (_currentHuman == frontHuman) return true;

            UpdateHumanState(frontHuman);
        }

        return true;
    }

    private void UpdateHumanState(GameObject human)
    {
        _currentHuman.SetActive(false);
        _currentHuman = human;
        _currentHuman.SetActive(true);
    }
}