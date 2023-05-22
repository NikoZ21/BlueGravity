using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyScripts.ShopSystem
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private Image[] displaySprite;
        [SerializeField] private TMP_Text priceTag;
        [SerializeField] private Transform sellParent;
        [SerializeField] private Transform buyParent;
        public Clothes Clothes { get; set; }
        public void SetSellParent(Transform parent) => sellParent = parent;
        public void SetBuyParent(Transform parent) => buyParent = parent;


        private void Start()
        {
            if (displaySprite.Length != Clothes.frontSprite.Length) return;

            for (int i = 0; i < displaySprite.Length; i++)
            {
                displaySprite[i].sprite = Clothes.frontSprite[i];
            }

            priceTag.text = Clothes.price.ToString();
        }

        public void BuySellItem()
        {
            if (transform.parent == buyParent)
            {
                if (Wallet.Instance.SpendTheGold(Clothes.price))
                {
                    Inventory.Inventory.Instance.AddToInventory(Clothes);
                    transform.parent = sellParent;
                }
            }
            else
            {
                Inventory.Inventory.Instance.RemoveFromInventory(Clothes);
                Wallet.Instance.EarnTheGold(Clothes.price);
                transform.parent = buyParent;
            }
        }
    }
}