using MyScripts.ShopSystem;
using UnityEngine;

namespace MyScripts.ClothesManager
{
    public class EquipClothes : MonoBehaviour
    {
        [SerializeField] private SpriteGetter front;
        [SerializeField] private SpriteGetter back;
        [SerializeField] private SpriteGetter left;
        [SerializeField] private SpriteGetter right;

        public static EquipClothes Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void EquipCloth(Clothes clothes)
        {
            AssignClothes(front, clothes, clothes.frontSprite);
            AssignClothes(back, clothes, clothes.backSprite);
            AssignClothes(left, clothes, clothes.leftSprite);
            AssignClothes(right, clothes, clothes.leftSprite);
        }

        private void AssignClothes(SpriteGetter spriteGetter, Clothes clothes, Sprite[] sprites)
        {
            var sprite = spriteGetter.GetSprite(clothes.Type);

            if (clothes.frontSprite.Length == 0 || clothes.frontSprite == null)
            {
                sprite[0].sprite = null;
                return;
            }

            for (int i = 0; i < sprite.Length; i++)
            {
                sprite[i].sprite = sprites[i];
            }
        }
    }

    public enum ClothesType
    {
        Legs,
        Body,
        Head
    }
}