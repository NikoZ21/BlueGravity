using MyScripts.ClothesManager;
using UnityEngine;


namespace MyScripts.ShopSystem
{
    [CreateAssetMenu(menuName = "Clothes", fileName = "Clothes")]
    public class Clothes : ScriptableObject
    {
        [SerializeField] public Sprite[] frontSprite;
        [SerializeField] public Sprite[] backSprite;
        [SerializeField] public Sprite[] leftSprite;

        [SerializeField] public int price;

        [SerializeField] public ClothesType Type = ClothesType.Body;
    }
}