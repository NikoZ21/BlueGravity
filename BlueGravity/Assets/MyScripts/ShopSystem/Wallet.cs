using System;
using UnityEngine;

namespace MyScripts.ShopSystem
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int gold;

        public Action<int> OnGoldChanged;

        private void Start()
        {
            OnGoldChanged?.Invoke(gold);
        }

        public void SpendTheGold(int amount)
        {
            gold -= amount;
            OnGoldChanged?.Invoke(gold);
        }

        public void EarnTheGold(int amount)
        {
            gold += amount;
            OnGoldChanged?.Invoke(gold);
        }
    }
}