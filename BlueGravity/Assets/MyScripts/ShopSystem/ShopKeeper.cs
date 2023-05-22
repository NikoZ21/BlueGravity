using MyScripts.Interactable;
using UnityEngine;

namespace MyScripts.ShopSystem
{
    public class ShopKeeper : MonoBehaviour, IInteractable
    {
        [SerializeField] private UI_Shop shop;
        private DisplayInteractUI _displayInteractUI;

        private void Start()
        {
            shop.gameObject.SetActive(false);
            _displayInteractUI = GetComponentInChildren<DisplayInteractUI>();
        }

        public void Interact()
        {
            shop.gameObject.SetActive(true);
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
}