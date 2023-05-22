using System.Collections.Generic;
using MyScripts.ShopSystem;
using UnityEngine;

namespace MyScripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryItem inventoryItem;
        [SerializeField] private InventoryItem inventoryItemDual;
        [SerializeField] private Transform parent;
        public Dictionary<Clothes, InventoryItem> inventoryDic = new Dictionary<Clothes, InventoryItem>();
        public static Inventory Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void AddToInventory(Clothes clothes)
        {
            if (clothes.frontSprite.Length == 1)
            {
                var item = Instantiate(inventoryItem, parent);
                item.GetComponent<InventoryItem>().CreateItem(clothes);

                inventoryDic.Add(clothes, item.GetComponent<InventoryItem>());
            }
            else
            {
                var item = Instantiate(inventoryItemDual, parent);
                item.GetComponent<InventoryItem>().CreateItem(clothes);

                inventoryDic.Add(clothes, item.GetComponent<InventoryItem>());
            }
        }
    }
}