using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyScripts.ShopSystem
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private Image[] displaySprite;
        [SerializeField] private TMP_Text priceTag;
        public Clothes Clothes { get; set; }


        private void Start()
        {
            if (displaySprite.Length != Clothes.frontSprite.Length) return;

            for (int i = 0; i < displaySprite.Length; i++)
            {
                displaySprite[i].sprite = Clothes.frontSprite[i];
            }

            priceTag.text = Clothes.price.ToString();
        }

        public void BuyItem()
        {
            if (Wallet.Instance.SpendTheGold(Clothes.price))
            {
                Inventory.Inventory.Instance.AddToInventory(Clothes);
            }
        }
    }
}