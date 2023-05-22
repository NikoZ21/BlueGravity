using UnityEngine;

namespace MyScripts.ShopSystem
{
    public class UI_Shop : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private GameObject button;
        [SerializeField] private GameObject buttonDual;

        private void Awake()
        {
            var clothes = Resources.LoadAll<Clothes>("");

            foreach (var cloth in clothes)
            {
                if (cloth.frontSprite.Length == 1)
                {
                    var shopButton = Instantiate(button, parent);
                    shopButton.GetComponent<ShopButton>().Clothes = cloth;
                }
                else
                {
                    var shopButton = Instantiate(buttonDual, parent);
                    shopButton.GetComponent<ShopButton>().Clothes = cloth;
                }
            }
        }
    }
}