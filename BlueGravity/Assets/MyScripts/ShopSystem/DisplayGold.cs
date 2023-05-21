using System;
using TMPro;
using UnityEngine;

namespace MyScripts.ShopSystem
{
    public class DisplayGold : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldCounterText;
        [SerializeField] private Wallet wallet;

        private void Awake()
        {
            wallet.OnGoldChanged += SetGold;
        }

        private void SetGold(int amount)
        {
            goldCounterText.text = amount.ToString();
        }
    }
}