using MyScripts.Interactable;
using UnityEngine;

namespace MyScripts.SceneManagement
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Place place = Place.Shop;
        [SerializeField] private Door destinationDoor;
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private BoxCollider2D collider;
        [SerializeField] private LayerMask playerLayer;

        private Fader _fader;


        private void Start()
        {
            var parent = transform.parent;
            _fader = parent.transform.parent.GetComponent<Fader>();
            _fader.OnFadeOutFinished += ActivateCamera;
        }

        private void Update()
        {
            if (collider.IsTouchingLayers(playerLayer))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(_fader.FadeOutAndIn(destinationDoor.GetSpawnPoint()));
                }
            }
        }

        private void ActivateCamera(Transform destination)
        {
            if (!collider.IsTouchingLayers(playerLayer)) return;

            CameraManager.Instance.PickCamera(place).SetActive(false);
            CameraManager.Instance.PickCamera(destinationDoor.GetPlace()).SetActive(true);
        }

        public Place GetPlace() => place;

        public Transform GetSpawnPoint() => spawnPoint;

        public void Interact()
        {
            StartCoroutine(_fader.FadeOutAndIn(destinationDoor.GetSpawnPoint()));
        }

        public void DisplayUI()
        {
            throw new System.NotImplementedException();
        }
    }

    public enum Place
    {
        Town,
        Shop
    }
}