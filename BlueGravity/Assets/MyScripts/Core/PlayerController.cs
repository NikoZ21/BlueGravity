using System;
using MyScripts.Interactable;
using MyScripts.SceneManagement;
using UnityEngine;

namespace MyScripts.Core
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private GameObject frontHuman;

        [SerializeField] private GameObject backHuman;
        [SerializeField] private GameObject leftHuman;
        [SerializeField] private GameObject rightHuman;
        [SerializeField] private float speed;
        [SerializeField] private Animator animator;

        [Header("Interaction Settings")]
        [SerializeField] private float radius = 1;

        [SerializeField] private LayerMask interactableLayer;

        [Header("Inventory System")]
        [SerializeField] private GameObject inventory;

        private readonly int _idleAnimationId = Animator.StringToHash("Idle");
        private readonly int _walkAnimationId = Animator.StringToHash("Walk");

        private GameObject _currentHuman;
        private Rigidbody2D _rb;
        private CapsuleCollider2D _bodyCollider;

        private IInteractable _currentInteract;
        private Vector2 _moveMent;
        private bool isEnabled = true;


        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _bodyCollider = GetComponent<CapsuleCollider2D>();

            _currentHuman = frontHuman;
            _currentHuman.SetActive(true);

            Fader.Instance.OnFadeOutStarted += EnableMovement;
            Fader.Instance.OnFadeInFinished += EnableMovement;
            Fader.Instance.OnFadeOutFinished += MoveTo;
        }

        void Update()
        {
            Interacte();

            DisplayInventory();

            if (isEnabled)
            {
                _moveMent.x = Input.GetAxis("Horizontal");
                _moveMent.y = Input.GetAxis("Vertical");

                if (IsMoving()) return;
            }

            animator.CrossFade(_idleAnimationId, 0, 0);
        }

        private void DisplayInventory()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventory.SetActive(!inventory.activeSelf);
            }
        }

        private void Interacte()
        {
            var interactables = Physics2D.OverlapCircleAll(transform.position, radius, interactableLayer);

            if (interactables.Length > 0)
            {
                _currentInteract = interactables[0].GetComponent<IInteractable>();

                _currentInteract.DisplayUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _currentInteract.Interact();
                }
            }
            else
            {
                if (_currentInteract != null)
                {
                    _currentInteract.RemoveUI();
                    _currentInteract = null;
                }
            }
        }

        private void FixedUpdate()
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

            return false;
        }

        private void UpdateHumanState(GameObject human)
        {
            _currentHuman.SetActive(false);
            _currentHuman = human;
            _currentHuman.SetActive(true);
        }

        private void MoveTo(Transform destination)
        {
            _rb.position = destination.position;
        }

        private void EnableMovement(bool state)
        {
            isEnabled = state;
            _moveMent = Vector2.zero;
            animator.CrossFade(_idleAnimationId, 0, 0);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}