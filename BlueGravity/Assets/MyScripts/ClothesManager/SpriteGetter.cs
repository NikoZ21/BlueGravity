using UnityEngine;

namespace MyScripts.ClothesManager
{
    public class SpriteGetter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] body;
        [SerializeField] private SpriteRenderer[] head;
        [SerializeField] private SpriteRenderer[] legs = new SpriteRenderer[2];

        public SpriteRenderer[] GetSprite(ClothesType type)
        {
            switch (type)
            {
                case ClothesType.Body:
                    return body;
                case ClothesType.Head:
                    return head;
                case ClothesType.Legs:
                    return legs;
            }

            return null;
        }
    }
}