using UnityEngine;

namespace MyScripts.ShopSystem
{
    public class UI_Shop : MonoBehaviour
    {
        [SerializeField] private Transform buyParent;
        [SerializeField] private Transform sellParent;
        [SerializeField] private GameObject button;
        [SerializeField] private GameObject buttonDual;

        private void Awake()
        {
            var clothes = Resources.LoadAll<Clothes>("");

            foreach (var cloth in clothes)
            {
                if (cloth.frontSprite.Length == 1)
                {
                    var shopButton = Instantiate(button, buyParent);
                    shopButton.GetComponent<ShopButton>().Clothes = cloth;
                    shopButton.GetComponent<ShopButton>().SetSellParent(sellParent);
                    shopButton.GetComponent<ShopButton>().SetBuyParent(buyParent);
                }
                else
                {
                    var shopButton = Instantiate(buttonDual, buyParent);
                    shopButton.GetComponent<ShopButton>().Clothes = cloth;
                    shopButton.GetComponent<ShopButton>().SetSellParent(sellParent);
                    shopButton.GetComponent<ShopButton>().SetBuyParent(buyParent);
                }
            }
        }
    }
}