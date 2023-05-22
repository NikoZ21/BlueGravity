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
        private DisplayInteractUI _displayInteractUI;

        private bool isOpen = false;

        private void Start()
        {
            _displayInteractUI = GetComponentInChildren<DisplayInteractUI>();

            Transform parent = transform.parent;
            _fader = parent.transform.parent.GetComponent<Fader>();

            _fader.OnFadeOutFinished += ActivateCamera;
        }

        private void ActivateCamera(Transform destination)
        {
            if (!isOpen) return;

            CameraManager.Instance.PickCamera(place).SetActive(false);
            CameraManager.Instance.PickCamera(destinationDoor.GetPlace()).SetActive(true);

            isOpen = false;
        }

        public Place GetPlace() => place;

        public Transform GetSpawnPoint() => spawnPoint;

        public void Interact()
        {
            StartCoroutine(_fader.FadeOutAndIn(destinationDoor.GetSpawnPoint()));
            isOpen = true;
        }

        public void DisplayUI()
        {
            _displayInteractUI.PopUpButton();
        }

        public void RemoveUI()
        {
            _displayInteractUI.ResetButtonScale();
        }
    }

    public enum Place
    {
        Town,
        Shop
    }
}