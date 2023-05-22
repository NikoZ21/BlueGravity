using System;
using UnityEngine;

namespace MyScripts.ShopSystem
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int gold;

        public Action<int> OnGoldChanged;

        public static Wallet Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            OnGoldChanged?.Invoke(gold);
        }

        public bool SpendTheGold(int amount)
        {
            if (amount <= gold)
            {
                gold -= amount;
                OnGoldChanged?.Invoke(gold);
                return true;
            }

            return false;
        }

        public void EarnTheGold(int amount)
        {
            gold += amount;
            OnGoldChanged?.Invoke(gold);
        }
    }
}