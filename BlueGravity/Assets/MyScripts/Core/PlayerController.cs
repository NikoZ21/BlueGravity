using MyScripts.SceneManagement;
using UnityEngine;

namespace MyScripts.Core
{
    public class PlayerController : MonoBehaviour
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
        private bool isEnabled = true;


        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _currentHuman = frontHuman;
            _currentHuman.SetActive(true);

            Fader.Instance.OnFadeOutStarted += EnableMovement;
            Fader.Instance.OnFadeInFinished += EnableMovement;
            Fader.Instance.OnFadeOutFinished += MoveTo;
        }

        void Update()
        {
            if (isEnabled)
            {
                _moveMent.x = Input.GetAxis("Horizontal");
                _moveMent.y = Input.GetAxis("Vertical");

                if (IsMoving()) return;
            }

            animator.CrossFade(_idleAnimationId, 0, 0);
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
    }
}