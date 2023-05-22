using System.Linq;
using MyScripts.ClothesManager;
using MyScripts.ShopSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyScripts.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image[] displaySprite;
        [SerializeField] private TMP_Text equippedText;
        private Clothes clothes;

        public void CreateItem(Clothes clothes)
        {
            this.clothes = clothes;
            Display();
        }

        public void EquipItem()
        {
            var keys = Inventory.Instance.inventoryDic.Keys.Where(c => c.Type == clothes.Type).ToList();

            foreach (var k in keys)
            {
                if (Inventory.Instance.inventoryDic[k].GetText() == "equipped")
                {
                    Inventory.Instance.inventoryDic[k].SetText("not equipped", Color.red);
                }
            }

            Inventory.Instance.inventoryDic[clothes].SetText("equipped", Color.green);

            EquipClothes.Instance.EquipCloth(clothes);
        }

        public string GetText()
        {
            return equippedText.text;
        }

        public void SetText(string text, Color color)
        {
            equippedText.text = text;
            equippedText.color = color;
        }

        private void Display()
        {
            if (displaySprite.Length != clothes.frontSprite.Length) return;

            for (int i = 0; i < displaySprite.Length; i++)
            {
                displaySprite[i].sprite = clothes.frontSprite[i];
            }
        }
    }
}