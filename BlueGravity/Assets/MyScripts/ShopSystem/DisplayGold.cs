using TMPro;
using UnityEngine;

namespace MyScripts.ShopSystem
{
    public class DisplayGold : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldCounterText;

        private void Awake()
        {
            Wallet.Instance.OnGoldChanged += SetGold;
        }

        private void SetGold(int amount)
        {
            goldCounterText.text = amount.ToString();
        }
    }
}